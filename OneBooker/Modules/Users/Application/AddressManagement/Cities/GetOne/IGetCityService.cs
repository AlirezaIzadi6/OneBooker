using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.GetOne;

public interface IGetCityService
{
    Task<Response<CityDto>> GetCityById(int cityId);
}