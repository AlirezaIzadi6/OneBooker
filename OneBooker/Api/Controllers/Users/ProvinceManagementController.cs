using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBooker.Api.Configurations.Auth;
using OneBooker.Api.Controllers.Base;
using OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;
using OneBooker.Modules.Users.InternalApis.AddressManagement.Interfaces;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

/// <summary>
/// Manage provinces.
/// </summary>
[ApiController]
[Route("api/v{versioning:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize(policy: AuthConstants.AdminPolicy)]
public class ProvinceManagementController(IProvinceManagementService provinceService) : BaseController
{
    /// <summary>
    /// Add a new province.
    /// </summary>
    /// <param name="province">ProvinceDto object containing new province info.</param>
    /// <returns>Unique identifier of the new province if created successfully.</returns>
    /// <response code="200">New province created successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response<int>>> Create([FromBody] ProvinceDto province)
    {
        return await provinceService.Create(province);
    }

    /// <summary>
    /// Get a list of provinces for a specific country.
    /// </summary>
    /// <param name="countryId">Unique identifier of the country.</param>
    /// <returns>A list of ProvinceDto objects.</returns>
    /// <response code="200">List of provinces retrieved successfully.</response>
    [HttpGet("country/{countryId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProvinceDto>))]
    public async Task<ActionResult<Response<IEnumerable<ProvinceDto>>>> List(int countryId)
    {
        return await provinceService.List(countryId);
    }

    /// <summary>
    /// Get a province by its unique identifier.
    /// </summary>
    /// <param name="id">Unique identifier of the province.</param>
    /// <returns>ProvinceDto object if found.</returns>
    /// <response code="200">Province found and returned successfully.</response>
    /// <response code="404">Province with the provided identifier does not exist.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProvinceDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<ProvinceDto>>> GetById(int id)
    {
        return await provinceService.GetById(id);
    }

    /// <summary>
    /// Update an existing province.
    /// </summary>
    /// <param name="id">Unique identifier of the province to update.</param>
    /// <param name="province">ProvinceDto object containing updated info.</param>
    /// <returns>A boolean value indicating success.</returns>
    /// <response code="200">Province updated successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    /// <response code="404">Province with the provided identifier does not exist.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<bool>>> Update(int id, [FromBody] ProvinceDto province)
    {
        return await provinceService.Update(id, province);
    }

    /// <summary>
    /// Delete a province.
    /// </summary>
    /// <param name="id">Unique identifier of the province to delete.</param>
    /// <returns>A boolean value indicating success.</returns>
    /// <response code="200">Province deleted successfully.</response>
    /// <response code="404">Province with the provided identifier does not exist.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        return await provinceService.Delete(id);
    }
}
