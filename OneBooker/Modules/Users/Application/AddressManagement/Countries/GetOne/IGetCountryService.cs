using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.GetOne;

public interface IGetCountryService
{
    Task<Response<CountryDto>> GetCountryById(int countryId);
}