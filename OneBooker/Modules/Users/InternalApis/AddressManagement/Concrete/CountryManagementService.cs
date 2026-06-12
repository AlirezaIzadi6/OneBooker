using OneBooker.Modules.Users.Application.AddressManagement.Countries.Create;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Delete;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.GetOne;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.List;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Update;
using OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.InternalApis.AddressManagement.Concrete;

public class CountryManagementService(
    ICreateCountryService createService,
    IUpdateCountryService updateService,
    IDeleteCountryService deleteService,
    IGetCountryService getService,
    IListCountryService listService) : ICountryManagementService, IScopedService
{
    public async Task<Response<int>> Create(CountryDto country)
    {
        return await createService.CreateCountry(country);
    }

    public async Task<Response<bool>> Update(int countryId, CountryDto country)
    {
        return await updateService.UpdateCountry(countryId, country);
    }

    public async Task<Response<bool>> Delete(int countryId)
    {
        return await deleteService.DeleteCountry(countryId);
    }

    public async Task<Response<CountryDto>> GetById(int countryId)
    {
        return await getService.GetCountryById(countryId);
    }

    public async Task<Response<IEnumerable<CountryDto>>> List()
    {
        return await listService.ListCountries();
    }
}