using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.Create;

public interface ICreateProvinceService
{
    Task<Response<int>> CreateProvince(ProvinceDto province);
}