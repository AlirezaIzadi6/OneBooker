using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBooker.Api.Configurations.Auth;
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
[Authorize(policy: AuthConstants.AdminPolicy)]
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

    /// <summary>
    /// Get a list of all countries.
    /// </summary>
    /// <returns>A list of CountryDto objects.</returns>
    /// <response code="200">List of countries retrieved successfully.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CountryDto>))]
    public async Task<ActionResult<Response<IEnumerable<CountryDto>>>> List()
    {
        return await countryService.List();
    }

    /// <summary>
    /// Get a country by its unique identifier.
    /// </summary>
    /// <param name="id">Unique identifier of the country.</param>
    /// <returns>CountryDto object if found.</returns>
    /// <response code="200">Country found and returned successfully.</response>
    /// <response code="404">Country with the provided identifier does not exist.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<CountryDto>>> GetById(int id)
    {
        return await countryService.GetById(id);
    }

    /// <summary>
    /// Update an existing country.
    /// </summary>
    /// <param name="id">Unique identifier of the country to update.</param>
    /// <param name="country">CountryDto object containing updated info.</param>
    /// <returns>A boolean value indicating success.</returns>
    /// <response code="200">Country updated successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    /// <response code="404">Country with the provided identifier does not exist.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<bool>>> Update(int id, [FromBody] CountryDto country)
    {
        return await countryService.Update(id, country);
    }

    /// <summary>
    /// Delete a country.
    /// </summary>
    /// <param name="id">Unique identifier of the country to delete.</param>
    /// <returns>A boolean value indicating success.</returns>
    /// <response code="200">Country deleted successfully.</response>
    /// <response code="404">Country with the provided identifier does not exist.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        return await countryService.Delete(id);
    }
}