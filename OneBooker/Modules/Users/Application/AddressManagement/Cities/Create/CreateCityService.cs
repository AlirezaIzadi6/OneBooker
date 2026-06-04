using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Create;

public class CreateCityService(ICityRepository cities, IGlobalizationService globalizationService) : ICreateCityService, IScopedService
{
    public async Task<Response<int>> CreateCity(CityDto city)
    {
        bool isNameDuplicate = await cities.IsNameDuplicate(city.Name, city.ProvinceId);
        if (isNameDuplicate)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.DuplicateItem),
                nameof(City));
            return Response<int>.Fail(errorMessage);
        }

        var createdCity = new City
        {
            Name = city.Name,
            ProvinceId = city.ProvinceId,
            IsActive = city.IsActive,
        };

        int createdId = await cities.Create(createdCity);

        return Response<int>.Success(createdId);
    }
}
