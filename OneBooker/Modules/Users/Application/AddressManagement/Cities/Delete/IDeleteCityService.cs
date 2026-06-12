using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Delete;

public interface IDeleteCityService
{
    Task<Response<bool>> DeleteCity(int cityId);
}