using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.List;

public class ListCountryService(ICountryRepository countries) : IListCountryService, IScopedService
{
    public async Task<Response<IEnumerable<CountryDto>>> ListCountries()
    {
        IEnumerable<Country> allCountries = await countries.ListAll();

        IEnumerable<CountryDto> dtos = allCountries.Select(
            c => new CountryDto
            {
                Id = c.Id,
                Name = c.Name,
                IsActive = c.IsActive,
            });

        return Response<IEnumerable<CountryDto>>.Success(dtos);
    }
}