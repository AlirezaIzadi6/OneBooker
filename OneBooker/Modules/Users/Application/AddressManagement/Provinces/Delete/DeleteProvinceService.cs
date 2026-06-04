using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.Delete;

public class DeleteProvinceService(IProvinceRepository provinces, IGlobalizationService globalizationService) : IDeleteProvinceService, IScopedService
{
    public async Task<Response<bool>> DeleteProvince(int provinceId)
    {
        Province province = await provinces.FindById(provinceId);
        if (province == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(Province));
            return Response<bool>.Fail(errorMessage);
        }

        await provinces.Delete(province);

        return Response<bool>.Success(true);
    }
}
