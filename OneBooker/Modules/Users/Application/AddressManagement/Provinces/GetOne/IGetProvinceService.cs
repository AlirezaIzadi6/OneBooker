using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.GetOne;

public interface IGetProvinceService
{
    Task<Response<ProvinceDto>> GetProvinceById(int provinceId);
}