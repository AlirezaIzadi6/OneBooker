using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Create;

public interface ICreateCityService
{
    Task<Response<int>> CreateCity(CityDto city);
}
