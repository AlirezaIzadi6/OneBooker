using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.List;

public class ListCityService(ICityRepository cities) : IListCityService, IScopedService
{
    public async Task<Response<IEnumerable<CityDto>>> ListCities(int provinceId)
    {
        ICollection<City> cityEntities = await cities.ListByProvince(provinceId);

        IEnumerable<CityDto> cityDtos = cityEntities.Select(c => new CityDto
        {
            Id = c.Id,
            Name = c.Name,
            ProvinceId = c.ProvinceId,
            IsActive = c.IsActive,
        });

        return Response<IEnumerable<CityDto>>.Success(cityDtos);
    }
}
