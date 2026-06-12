using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Delete;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.AddressManagement.Countries.Delete;

public class DeleteCountryServiceTests
{
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly Mock<ICountryRepository> _repoMock;
    private readonly DeleteCountryService _service;

    public DeleteCountryServiceTests()
    {
        _repoMock = new Mock<ICountryRepository>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new DeleteCountryService(_repoMock.Object, _globalizationMock.Object);
    }

    [Fact]
    public async Task DeleteCountry_WhenCountryNotFound_ShouldReturnNotFound()
    {
        // Arrange
        int countryId = 1;
        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync((Country)null);
        _globalizationMock.Setup(g => g.Localize(It.IsAny<Messages>())).Returns("Not Found {0}");

        // Act
        Response<bool>? result = await _service.DeleteCountry(countryId);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorType.Should().Be(ErrorType.NotFound);
        _repoMock.Verify(r => r.Delete(It.IsAny<Country>()), Times.Never);
    }

    [Fact]
    public async Task DeleteCountry_WhenCountryExists_ShouldReturnSuccess()
    {
        // Arrange
        int countryId = 1;
        var existingCountry = new Country
        {
            Id = countryId,
            Name = "Canada",
        };
        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync(existingCountry);

        // Act
        Response<bool>? result = await _service.DeleteCountry(countryId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _repoMock.Verify(r => r.Delete(existingCountry), Times.Once);
    }
}