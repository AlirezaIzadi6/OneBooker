using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.GetOne;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Tests.Modules.Users.Application.AddressManagement.Countries.GetOne;

public class GetCountryServiceTests
{
    private readonly Mock<IGlobalizationService> _globalizationMock;
    private readonly Mock<ICountryRepository> _repoMock;
    private readonly GetCountryService _service;

    public GetCountryServiceTests()
    {
        _repoMock = new Mock<ICountryRepository>();
        _globalizationMock = new Mock<IGlobalizationService>();
        _service = new GetCountryService(_repoMock.Object, _globalizationMock.Object);
    }

    [Fact]
    public async Task GetCountryById_WhenCountryNotFound_ShouldReturnNotFound()
    {
        // Arrange
        int countryId = 1;
        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync((Country)null);
        _globalizationMock.Setup(g => g.Localize(It.IsAny<Messages>())).Returns("Not Found {0}");

        // Act
        Response<CountryDto> result = await _service.GetCountryById(countryId);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.ErrorType.Should().Be(ErrorType.NotFound);
    }

    [Fact]
    public async Task GetCountryById_WhenCountryExists_ShouldReturnSuccessWithDto()
    {
        // Arrange
        int countryId = 1;
        var existingCountry = new Country
        {
            Id = countryId,
            Name = "Canada",
            IsActive = true,
        };
        _repoMock.Setup(r => r.FindById(countryId)).ReturnsAsync(existingCountry);

        // Act
        Response<CountryDto> result = await _service.GetCountryById(countryId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        Assert.NotNull(result.Data);
        result.Data!.Id.Should().Be(countryId);
        result.Data.Name.Should().Be("Canada");
        result.Data.IsActive.Should().Be(true);
    }
}