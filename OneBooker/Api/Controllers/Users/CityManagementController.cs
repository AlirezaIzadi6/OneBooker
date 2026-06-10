using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBooker.Api.Configurations.Auth;
using OneBooker.Api.Controllers.Base;
using OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;
using OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

/// <summary>
/// Manage cities.
/// </summary>
[ApiController]
[Route("api/v{versioning:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize(policy: AuthConstants.AdminPolicy)]
public class CityManagementController(ICityManagementService cityService) : BaseController
{
    /// <summary>
    /// Add a new city.
    /// </summary>
    /// <param name="city">CityDto object containing new city info.</param>
    /// <returns>Unique identifier of the new city if created successfully.</returns>
    /// <response code="200">New city created successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response<int>>> Create([FromBody] CityDto city)
    {
        return await cityService.Create(city);
    }

    /// <summary>
    /// Get a list of cities for a specific province.
    /// </summary>
    /// <param name="provinceId">Unique identifier of the province.</param>
    /// <returns>A list of CityDto objects.</returns>
    /// <response code="200">List of cities retrieved successfully.</response>
    [HttpGet("province/{provinceId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CityDto>))]
    public async Task<ActionResult<Response<IEnumerable<CityDto>>>> List(int provinceId)
    {
        return await cityService.List(provinceId);
    }

    /// <summary>
    /// Get a city by its unique identifier.
    /// </summary>
    /// <param name="id">Unique identifier of the city.</param>
    /// <returns>CityDto object if found.</returns>
    /// <response code="200">City found and returned successfully.</response>
    /// <response code="404">City with the provided identifier does not exist.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CityDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<CityDto>>> GetById(int id)
    {
        return await cityService.GetById(id);
    }

    /// <summary>
    /// Update an existing city.
    /// </summary>
    /// <param name="id">Unique identifier of the city to update.</param>
    /// <param name="city">CityDto object containing updated info.</param>
    /// <returns>A boolean value indicating success.</returns>
    /// <response code="200">City updated successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    /// <response code="404">City with the provided identifier does not exist.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<bool>>> Update(int id, [FromBody] CityDto city)
    {
        return await cityService.Update(id, city);
    }

    /// <summary>
    /// Delete a city.
    /// </summary>
    /// <param name="id">Unique identifier of the city to delete.</param>
    /// <returns>A boolean value indicating success.</returns>
    /// <response code="200">City deleted successfully.</response>
    /// <response code="404">City with the provided identifier does not exist.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        return await cityService.Delete(id);
    }
}
