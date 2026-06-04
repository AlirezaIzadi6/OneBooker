using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Delete;

public class DeleteCityService(ICityRepository cities, IGlobalizationService globalizationService) : IDeleteCityService, IScopedService
{
    public async Task<Response<bool>> DeleteCity(int cityId)
    {
        var city = await cities.FindById(cityId);
        if (city == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(City));
            return Response<bool>.Fail(errorMessage);
        }

        await cities.Delete(city);

        return Response<bool>.Success(true);
    }
}
