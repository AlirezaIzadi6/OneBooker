using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Update;

public class UpdateCountryService(ICountryRepository countries, IGlobalizationService globalizationService) : IUpdateCountryService, IScopedService
{
    public async Task<Response<bool>> UpdateCountry(int countryId, string name, bool isActive)
    {
        Country country = await countries.FindById(countryId);
        if (country is null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(Country));
            return Response<bool>.NotFound(errorMessage);
        }

        if (await NameIsDuplicate(name, country))
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.DuplicateItem),
                nameof(Country));
            return Response<bool>.Fail(errorMessage);
        }

        country.Name = name;
        country.IsActive = isActive;
        await countries.Update(country);

        return Response<bool>.Success(true);
    }

    private async Task<bool> NameIsDuplicate(string name, Country country)
    {
        if (name == country.Name) return false;
        return await countries.IsNameDuplicate(name);
    }
}