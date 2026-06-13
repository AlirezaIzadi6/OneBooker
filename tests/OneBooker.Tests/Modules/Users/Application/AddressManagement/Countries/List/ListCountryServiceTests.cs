using FluentAssertions;
using Moq;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.List;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Tests.Modules.Users.Application.AddressManagement.Countries.List;

public class ListCountryServiceTests
{
    private readonly Mock<ICountryRepository> _repoMock;
    private readonly ListCountryService _service;

    public ListCountryServiceTests()
    {
        _repoMock = new Mock<ICountryRepository>();
        _service = new ListCountryService(_repoMock.Object);
    }

    [Fact]
    public async Task ListCountries_ShouldReturnAllCountriesAsDtos()
    {
        // Arrange
        var countries = new List<Country>
        {
            new()
            {
                Id = 1,
                Name = "Canada",
                IsActive = true,
            },
            new()
            {
                Id = 2,
                Name = "Iran",
                IsActive = true,
            },
        };
        _repoMock.Setup(r => r.ListAll()).ReturnsAsync(countries);

        // Act
        Response<IEnumerable<CountryDto>> result = await _service.ListCountries();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().HaveCount(2);
        result.Data.Should().Contain(c => c.Name == "Canada");
        result.Data.Should().Contain(c => c.Name == "Iran");
    }

    [Fact]
    public async Task ListCountries_WhenEmpty_ShouldReturnEmptyList()
    {
        // Arrange
        _repoMock.Setup(r => r.ListAll()).ReturnsAsync([]);

        // Act
        Response<IEnumerable<CountryDto>> result = await _service.ListCountries();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEmpty();
    }
}