using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.List;

public interface IListProvinceService
{
    Task<Response<IEnumerable<ProvinceDto>>> ListProvinces(int countryId);
}