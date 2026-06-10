using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.List;

public class ListProvinceService(IProvinceRepository provinces) : IListProvinceService, IScopedService
{
    public async Task<Response<IEnumerable<ProvinceDto>>> ListProvinces(int countryId)
    {
        ICollection<Province> provinceEntities = await provinces.ListByCountry(countryId);

        IEnumerable<ProvinceDto> provinceDtos = provinceEntities.Select(p => new ProvinceDto
        {
            Id = p.Id,
            Name = p.Name,
            CountryId = p.CountryId,
            IsActive = p.IsActive,
        });

        return Response<IEnumerable<ProvinceDto>>.Success(provinceDtos);
    }
}
