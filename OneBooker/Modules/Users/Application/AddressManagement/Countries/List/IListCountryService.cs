using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.List;

public interface IListCountryService
{
    Task<Response<IEnumerable<CountryDto>>> ListCountries();
}