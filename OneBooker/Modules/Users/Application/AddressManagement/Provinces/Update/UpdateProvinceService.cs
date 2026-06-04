using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.Update;

public class UpdateProvinceService(IProvinceRepository provinces, IGlobalizationService globalizationService) : IUpdateProvinceService, IScopedService
{
    public async Task<Response<bool>> UpdateProvince(int provinceId, ProvinceDto province)
    {
        var existingProvince = await provinces.FindById(provinceId);
        if (existingProvince == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(Province));
            return Response<bool>.Fail(errorMessage);
        }

        // Check if new name is duplicate (if name changed)
        if (existingProvince.Name != province.Name)
        {
            bool isNameDuplicate = await provinces.IsNameDuplicate(province.Name, existingProvince.CountryId);
            if (isNameDuplicate)
            {
                string errorMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    globalizationService.Localize(Messages.DuplicateItem),
                    nameof(Province));
                return Response<bool>.Fail(errorMessage);
            }
        }

        existingProvince.Name = province.Name;
        existingProvince.IsActive = province.IsActive;

        await provinces.Update(existingProvince);

        return Response<bool>.Success(true);
    }
}
