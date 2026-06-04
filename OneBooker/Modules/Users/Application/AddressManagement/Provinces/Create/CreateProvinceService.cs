using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.Create;

public class CreateProvinceService(IProvinceRepository provinces, IGlobalizationService globalizationService) : ICreateProvinceService, IScopedService
{
    public async Task<Response<int>> CreateProvince(ProvinceDto province)
    {
        bool isNameDuplicate = await provinces.IsNameDuplicate(province.Name, province.CountryId);
        if (isNameDuplicate)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.DuplicateItem),
                nameof(Province));
            return Response<int>.Fail(errorMessage);
        }

        var createdProvince = new Province
        {
            Name = province.Name,
            CountryId = province.CountryId,
            IsActive = province.IsActive,
        };

        int createdId = await provinces.Create(createdProvince);

        return Response<int>.Success(createdId);
    }
}
