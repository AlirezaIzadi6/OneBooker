using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Create;

public interface ICreateCountryService
{
    Task<Response<int>> CreateCountry(string name, bool isActive);
}