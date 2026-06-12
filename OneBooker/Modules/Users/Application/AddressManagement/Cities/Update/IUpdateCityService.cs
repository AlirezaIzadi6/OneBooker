using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Update;

public interface IUpdateCityService
{
    Task<Response<bool>> UpdateCity(int cityId, CityDto city);
}