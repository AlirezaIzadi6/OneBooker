using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Update;

public interface IUpdateCountryService
{
    Task<Response<bool>> UpdateCountry(int countryId, CountryDto country);
}