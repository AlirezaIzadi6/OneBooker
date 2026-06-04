using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.GetOne;

public class GetProvinceService(IProvinceRepository provinces, IGlobalizationService globalizationService) : IGetProvinceService, IScopedService
{
    public async Task<Response<ProvinceDto>> GetProvinceById(int provinceId)
    {
        var province = await provinces.FindById(provinceId);
        if (province == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(Province));
            return Response<ProvinceDto>.Fail(errorMessage);
        }

        var provinceDto = new ProvinceDto
        {
            Id = province.Id,
            Name = province.Name,
            CountryId = province.CountryId,
            IsActive = province.IsActive,
        };

        return Response<ProvinceDto>.Success(provinceDto);
    }
}
