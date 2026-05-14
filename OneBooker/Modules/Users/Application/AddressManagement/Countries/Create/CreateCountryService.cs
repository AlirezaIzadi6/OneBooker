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
    public async Task<Response<int>> CreateCountry(string name, bool isActive)
    {
        bool isNameDuplicate = await countries.IsNameDuplicate(name);
        if (isNameDuplicate)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.DuplicateItem),
                nameof(Country));
            return Response<int>.Fail(errorMessage);
        }

        var country = new Country
        {
            Name = name,
            IsActive = isActive,
        };

        int createdId = await countries.Create(country);

        return Response<int>.Success(createdId);
    }
}