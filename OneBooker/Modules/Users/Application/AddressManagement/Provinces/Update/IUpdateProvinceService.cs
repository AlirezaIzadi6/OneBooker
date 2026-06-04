using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.Update;

public interface IUpdateProvinceService
{
    Task<Response<bool>> UpdateProvince(int provinceId, ProvinceDto province);
}
