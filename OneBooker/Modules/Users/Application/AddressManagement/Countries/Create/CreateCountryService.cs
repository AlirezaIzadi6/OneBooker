using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Create;

public class CreateCountryService(ICountryRepository countries, IGlobalizationService globalizationService) : ICreateCountryService, IScopedService
{
    public async Task<Response<int>> CreateCountry(CountryDto country)
    {
        bool isNameDuplicate = await countries.IsNameDuplicate(country.Name);
        if (isNameDuplicate)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.DuplicateItem),
                nameof(Country));
            return Response<int>.Fail(errorMessage);
        }

        var createdCountry = new Country
        {
            Name = country.Name,
            IsActive = country.IsActive,
        };

        int createdId = await countries.Create(createdCountry);

        return Response<int>.Success(createdId);
    }
}