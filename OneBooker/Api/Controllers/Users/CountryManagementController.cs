using Microsoft.AspNetCore.Mvc;
using OneBooker.Api.Controllers.Base;
using OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;
using OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

/// <summary>
/// Manage countries.
/// </summary>
[ApiController]
[Route("api/v{versioning:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CountryManagementController(ICountryManagementService countryService) : BaseController
{
    /// <summary>
    /// Add a new country.
    /// </summary>
    /// <param name="country">CountryDto object containing new country info.</param>
    /// <returns>Unique identifier of the new country if created successfully.</returns>
    /// <response code="200">New country created successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response<int>>> Create([FromBody] CountryDto country)
    {
        return await countryService.Create(country);
    }
}