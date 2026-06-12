using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Create;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.AddressManagement.Countries.Create;

public class CreateCountryServiceTests
{
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly Mock<ICountryRepository> _repoMock;
    private readonly CreateCountryService _service;

    public CreateCountryServiceTests()
    {
        _repoMock = new Mock<ICountryRepository>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new CreateCountryService(_repoMock.Object, _globalizationMock.Object);
    }

    [Fact]
    public async Task CreateCountry_WhenNameIsDuplicate_ShouldReturnFailResponse()
    {
        // Arrange
        var countryDto = new CountryDto
        {
            Name = "Iran",
            IsActive = true,
        };
        _repoMock.Setup(r => r.IsNameDuplicate(countryDto.Name)).ReturnsAsync(true);
        _globalizationMock.Setup(g => g.Localize(It.IsAny<Messages>())).Returns("Duplicate Item {0}");

        // Act
        Response<int>? result = await _service.CreateCountry(countryDto);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Contain("Duplicate");
        _repoMock.Verify(r => r.Create(It.IsAny<Country>()), Times.Never);
    }

    [Fact]
    public async Task CreateCountry_WhenNameIsNotDuplicate_ShouldReturnSuccessResponse()
    {
        // Arrange
        var countryDto = new CountryDto
        {
            Name = "Canada",
            IsActive = true,
        };
        _repoMock.Setup(r => r.IsNameDuplicate(countryDto.Name)).ReturnsAsync(false);
        _repoMock.Setup(r => r.Create(It.IsAny<Country>())).ReturnsAsync(1);

        // Act
        Response<int>? result = await _service.CreateCountry(countryDto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().Be(1);
        _repoMock.Verify(r => r.Create(It.Is<Country>(c => c.Name == "Canada")), Times.Once);
    }
}