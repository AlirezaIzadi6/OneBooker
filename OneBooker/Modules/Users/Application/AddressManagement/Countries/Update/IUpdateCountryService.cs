using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Update;

public interface IUpdateCountryService
{
    Task<Response<bool>> UpdateCountry(int countryId, string name, bool isActive);
}