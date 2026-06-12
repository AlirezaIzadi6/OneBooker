using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using OneBooker.SharedKernel.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Delete;

public class DeleteCityService(ICityRepository cities, IGlobalizationService globalizationService)
    : IDeleteCityService, IScopedService
{
    public async Task<Response<bool>> DeleteCity(int cityId)
    {
        City city = await cities.FindById(cityId);
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