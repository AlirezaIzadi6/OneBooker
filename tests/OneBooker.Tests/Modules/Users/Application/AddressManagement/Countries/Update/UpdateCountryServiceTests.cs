using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Update;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.AddressManagement.Countries.Update;

public class UpdateCountryServiceTests
{
    private readonly Mock<ICountryRepository> _repoMock;
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly UpdateCountryService _service;

    public UpdateCountryServiceTests()
    {
        _repoMock = new Mock<ICountryRepository>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new UpdateCountryService(_repoMock.Object, _globalizationMock.Object);
    }

    [Fact]
    public async Task UpdateCountry_WhenCountryNotFound_ShouldReturnNotFound()
    {
        // Arrange
        int countryId = 1;
        var countryDto = new CountryDto { Name = "Updated", IsActive = true };
        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync((Country)null);
        _globalizationMock.Setup(g => g.Localize(Messages.NotFound)).Returns("{0} not found");

        // Act
        var result = await _service.UpdateCountry(countryId, countryDto);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorType.Should().Be(ErrorType.NotFound);
        result.ErrorMessage.Should().Contain("Country");
    }

    [Fact]
    public async Task UpdateCountry_WhenNameIsDuplicate_ShouldReturnFail()
    {
        // Arrange
        int countryId = 1;
        var countryDto = new CountryDto { Name = "ExistingName", IsActive = true };
        var existingCountry = new Country { Id = countryId, Name = "OldName", IsActive = true };

        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync(existingCountry);
        _repoMock.Setup(r => r.IsNameDuplicate(countryDto.Name)).ReturnsAsync(true);
        _globalizationMock.Setup(g => g.Localize(Messages.DuplicateItem)).Returns("Duplicate {0}");

        // Act
        var result = await _service.UpdateCountry(countryId, countryDto);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorMessage.Should().Contain("Country");
        _repoMock.Verify(r => r.Update(It.IsAny<Country>()), Times.Never);
    }

    [Fact]
    public async Task UpdateCountry_WhenDataIsValid_ShouldReturnSuccess()
    {
        // Arrange
        int countryId = 1;
        var countryDto = new CountryDto { Name = "NewName", IsActive = false };
        var existingCountry = new Country { Id = countryId, Name = "OldName", IsActive = true };

        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync(existingCountry);
        _repoMock.Setup(r => r.IsNameDuplicate(countryDto.Name)).ReturnsAsync(false);

        // Act
        var result = await _service.UpdateCountry(countryId, countryDto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        existingCountry.Name.Should().Be(countryDto.Name);
        existingCountry.IsActive.Should().Be(countryDto.IsActive);
        _repoMock.Verify(r => r.Update(existingCountry), Times.Once);
    }

    [Fact]
    public async Task UpdateCountry_WhenNameIsSame_ShouldNotCheckDuplicationAndReturnSuccess()
    {
        // Arrange
        int countryId = 1;
        var countryDto = new CountryDto { Name = "SameName", IsActive = false };
        var existingCountry = new Country { Id = countryId, Name = "SameName", IsActive = true };

        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync(existingCountry);

        // Act
        var result = await _service.UpdateCountry(countryId, countryDto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repoMock.Verify(r => r.IsNameDuplicate(It.IsAny<string>()), Times.Never);
        _repoMock.Verify(r => r.Update(existingCountry), Times.Once);
    }
}
