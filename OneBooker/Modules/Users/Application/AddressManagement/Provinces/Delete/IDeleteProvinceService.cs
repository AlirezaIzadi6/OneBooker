using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.Delete;

public interface IDeleteProvinceService
{
    Task<Response<bool>> DeleteProvince(int provinceId);
}