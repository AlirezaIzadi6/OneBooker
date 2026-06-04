using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.List;

public interface IListCityService
{
    Task<Response<IEnumerable<CityDto>>> ListCities(int provinceId);
}
