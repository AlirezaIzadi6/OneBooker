using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Create;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.AddressManagement.Provinces.Create;

public class CreateProvinceServiceTests
{
    private readonly Mock<IProvinceRepository> _repoMock;
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly CreateProvinceService _service;

    public CreateProvinceServiceTests()
    {
        _repoMock = new Mock<IProvinceRepository>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new CreateProvinceService(_repoMock.Object, _globalizationMock.Object);
    }

    [Fact]
    public async Task CreateProvince_WhenNameIsDuplicateInCountry_ShouldReturnFail()
    {
        // Arrange
        var provinceDto = new ProvinceDto { Name = "Ontario", CountryId = 1, IsActive = true };
        _repoMock.Setup(r => r.IsNameDuplicate(provinceDto.Name, provinceDto.CountryId)).ReturnsAsync(true);
        _globalizationMock.Setup(g => g.Localize(It.IsAny<Messages>())).Returns("Duplicate {0}");

        // Act
        var result = await _service.CreateProvince(provinceDto);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Contain("Province");
        _repoMock.Verify(r => r.Create(It.IsAny<Province>()), Times.Never);
    }

    [Fact]
    public async Task CreateProvince_WhenDataIsValid_ShouldReturnSuccess()
    {
        // Arrange
        var provinceDto = new ProvinceDto { Name = "Quebec", CountryId = 1, IsActive = true };
        _repoMock.Setup(r => r.IsNameDuplicate(provinceDto.Name, provinceDto.CountryId)).ReturnsAsync(false);
        _repoMock.Setup(r => r.Create(It.IsAny<Province>())).ReturnsAsync(5);

        // Act
        var result = await _service.CreateProvince(provinceDto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().Be(5);
        _repoMock.Verify(r => r.Create(It.Is<Province>(p => p.Name == "Quebec" && p.CountryId == 1)), Times.Once);
    }
}
