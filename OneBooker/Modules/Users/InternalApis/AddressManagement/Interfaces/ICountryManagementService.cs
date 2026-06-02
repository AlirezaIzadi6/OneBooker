using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;

public interface ICountryManagementService
{
    Task<Response<int>> Create(CountryDto country);
}
