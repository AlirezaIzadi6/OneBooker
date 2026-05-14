using OneBooker.Modules.Users.Application.Common.Extentions;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Delete;

public class DeleteCountryService(ICountryRepository countries, IGlobalizationService globalizationService) : IDeleteCountryService, IScopedService
{
    public async Task<Response<bool>> DeleteCountry(int countryId)
    {
        Country country = await countries.FindById(countryId);

        if (country is null)
        {
            return Response<bool>.NotFound(globalizationService.NotFoundError(nameof(Country)));
        }

        await countries.Delete(country);

        return Response<bool>.Success(true);
    }
}