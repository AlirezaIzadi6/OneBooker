using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;

public interface ICountryManagementService
{
    Task<Response<int>> Create(CountryDto country);
    Task<Response<bool>> Update(int countryId, CountryDto country);
    Task<Response<bool>> Delete(int countryId);

    Task<Response<CountryDto>> GetById(int countryId);
    Task<Response<IEnumerable<CountryDto>>> List();
}