using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Create;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Delete;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.GetOne;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.List;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Update;
using OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.InternalApis.AddressManagement.Concrete;

public class ProvinceManagementService(
    ICreateProvinceService createService,
    IUpdateProvinceService updateService,
    IDeleteProvinceService deleteService,
    IGetProvinceService getService,
    IListProvinceService listService) : IProvinceManagementService, IScopedService
{
    public async Task<Response<int>> Create(ProvinceDto province)
    {
        return await createService.CreateProvince(province);
    }

    public async Task<Response<bool>> Update(int provinceId, ProvinceDto province)
    {
        return await updateService.UpdateProvince(provinceId, province);
    }

    public async Task<Response<bool>> Delete(int provinceId)
    {
        return await deleteService.DeleteProvince(provinceId);
    }

    public async Task<Response<ProvinceDto>> GetById(int provinceId)
    {
        return await getService.GetProvinceById(provinceId);
    }

    public async Task<Response<IEnumerable<ProvinceDto>>> List(int countryId)
    {
        return await listService.ListProvinces(countryId);
    }
}
