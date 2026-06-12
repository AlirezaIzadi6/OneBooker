using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;

public interface ICityManagementService
{
    Task<Response<int>> Create(CityDto city);

    Task<Response<bool>> Update(int cityId, CityDto city);

    Task<Response<bool>> Delete(int cityId);

    Task<Response<CityDto>> GetById(int cityId);

    Task<Response<IEnumerable<CityDto>>> List(int provinceId);
}