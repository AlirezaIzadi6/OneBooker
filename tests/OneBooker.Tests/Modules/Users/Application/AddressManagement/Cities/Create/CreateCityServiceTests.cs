using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.Create;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.AddressManagement.Cities.Create;

public class CreateCityServiceTests
{
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly Mock<ICityRepository> _repoMock;
    private readonly CreateCityService _service;

    public CreateCityServiceTests()
    {
        _repoMock = new Mock<ICityRepository>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new CreateCityService(_repoMock.Object, _globalizationMock.Object);
    }

    [Fact]
    public async Task CreateCity_WhenNameIsDuplicateInProvince_ShouldReturnFail()
    {
        // Arrange
        var cityDto = new CityDto
        {
            Name = "Toronto",
            ProvinceId = 1,
            IsActive = true,
        };
        _repoMock.Setup(r => r.IsNameDuplicate(cityDto.Name, cityDto.ProvinceId)).ReturnsAsync(true);
        _globalizationMock.Setup(g => g.Localize(It.IsAny<Messages>())).Returns("Duplicate {0}");

        // Act
        Response<int> result = await _service.CreateCity(cityDto);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Contain("City");
        _repoMock.Verify(r => r.Create(It.IsAny<City>()), Times.Never);
    }

    [Fact]
    public async Task CreateCity_WhenDataIsValid_ShouldReturnSuccess()
    {
        // Arrange
        var cityDto = new CityDto
        {
            Name = "Vancouver",
            ProvinceId = 2,
            IsActive = true,
        };
        _repoMock.Setup(r => r.IsNameDuplicate(cityDto.Name, cityDto.ProvinceId)).ReturnsAsync(false);
        _repoMock.Setup(r => r.Create(It.IsAny<City>())).ReturnsAsync(10);

        // Act
        Response<int> result = await _service.CreateCity(cityDto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().Be(10);
        _repoMock.Verify(r => r.Create(It.Is<City>(c => c.Name == "Vancouver" && c.ProvinceId == 2)), Times.Once);
    }
}