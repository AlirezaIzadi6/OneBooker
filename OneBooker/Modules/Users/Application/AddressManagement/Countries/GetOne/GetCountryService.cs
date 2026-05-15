using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.Common.Extentions;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.GetOne;

public class GetCountryService(ICountryRepository countries, IGlobalizationService globalizationService) : IGetCountryService, IScopedService
{
    public async Task<Response<CountryDto>> GetCountryById(int countryId)
    {
        Country country = await countries.FindById(countryId);

        if (country is null)
        {
            return Response<CountryDto>.NotFound(globalizationService.NotFoundError(nameof(Country)));
        }

        var dto = new CountryDto
        {
            Id = country.Id,
            Name = country.Name,
            IsActive = country.IsActive,
        };

        return Response<CountryDto>.Success(dto);
    }
}