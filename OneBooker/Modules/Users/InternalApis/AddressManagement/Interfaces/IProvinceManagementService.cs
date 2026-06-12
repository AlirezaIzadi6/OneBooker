using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;

public interface IProvinceManagementService
{
    Task<Response<int>> Create(ProvinceDto province);

    Task<Response<bool>> Update(int provinceId, ProvinceDto province);

    Task<Response<bool>> Delete(int provinceId);

    Task<Response<ProvinceDto>> GetById(int provinceId);

    Task<Response<IEnumerable<ProvinceDto>>> List(int countryId);
}