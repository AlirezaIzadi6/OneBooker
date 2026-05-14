using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Delete;

public interface IDeleteCountryService
{
    Task<Response<bool>> DeleteCountry(int countryId);
}