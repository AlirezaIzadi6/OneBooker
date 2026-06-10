using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.GetOne;

public class GetCityService(ICityRepository cities, IGlobalizationService globalizationService) : IGetCityService, IScopedService
{
    public async Task<Response<CityDto>> GetCityById(int cityId)
    {
        City city = await cities.FindById(cityId);
        if (city == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(City));
            return Response<CityDto>.Fail(errorMessage);
        }

        var cityDto = new CityDto
        {
            Id = city.Id,
            Name = city.Name,
            ProvinceId = city.ProvinceId,
            IsActive = city.IsActive,
        };

        return Response<CityDto>.Success(cityDto);
    }
}
