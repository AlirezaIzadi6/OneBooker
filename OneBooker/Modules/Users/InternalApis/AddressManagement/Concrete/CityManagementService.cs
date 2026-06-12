using OneBooker.Modules.Users.Application.AddressManagement.Cities.Create;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.Delete;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.GetOne;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.List;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.Update;
using OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.InternalApis.AddressManagement.Concrete;

public class CityManagementService(
    ICreateCityService createService,
    IUpdateCityService updateService,
    IDeleteCityService deleteService,
    IGetCityService getService,
    IListCityService listService) : ICityManagementService, IScopedService
{
    public async Task<Response<int>> Create(CityDto city)
    {
        return await createService.CreateCity(city);
    }

    public async Task<Response<bool>> Update(int cityId, CityDto city)
    {
        return await updateService.UpdateCity(cityId, city);
    }

    public async Task<Response<bool>> Delete(int cityId)
    {
        return await deleteService.DeleteCity(cityId);
    }

    public async Task<Response<CityDto>> GetById(int cityId)
    {
        return await getService.GetCityById(cityId);
    }

    public async Task<Response<IEnumerable<CityDto>>> List(int provinceId)
    {
        return await listService.ListCities(provinceId);
    }
}