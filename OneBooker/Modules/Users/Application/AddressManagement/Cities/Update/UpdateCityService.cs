using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using OneBooker.SharedKernel.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Update;

public class UpdateCityService(ICityRepository cities, IGlobalizationService globalizationService)
    : IUpdateCityService, IScopedService
{
    public async Task<Response<bool>> UpdateCity(int cityId, CityDto city)
    {
        City existingCity = await cities.FindById(cityId);
        if (existingCity == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(City));
            return Response<bool>.Fail(errorMessage);
        }

        // Check if new name is duplicate (if name changed)
        if (existingCity.Name != city.Name)
        {
            bool isNameDuplicate = await cities.IsNameDuplicate(city.Name, existingCity.ProvinceId);
            if (isNameDuplicate)
            {
                string errorMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    globalizationService.Localize(Messages.DuplicateItem),
                    nameof(City));
                return Response<bool>.Fail(errorMessage);
            }
        }

        existingCity.Name = city.Name;
        existingCity.IsActive = city.IsActive;

        await cities.Update(existingCity);

        return Response<bool>.Success(true);
    }
}