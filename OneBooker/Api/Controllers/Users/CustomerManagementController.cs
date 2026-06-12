using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBooker.Api.Controllers.Base;
using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.Modules.Users.InternalApis.UserManagement.Interfaces;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

/// <summary>
///     Manage customers.
/// </summary>
[ApiController]
[Route("api/v{versioning:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
public class CustomerManagementController(ICustomerManagementService customerService) : BaseController
{
    /// <summary>
    ///     Add a new customer.
    /// </summary>
    /// <param name="customer">CustomerDto object containing new customer info.</param>
    /// <returns>Unique identifier of the new customer if created successfully.</returns>
    /// <response code="200">New customer created successfully.</response>
    /// <response code="400">Provided information are not valid or duplicate.</response>
    /// <response code="401">User is not authorized.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<int>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<int>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Response<int>>> Create([FromBody] CustomerDto customer)
    {
        return await customerService.Create(customer);
    }

    /// <summary>
    ///     Get a customer by its unique identifier.
    /// </summary>
    /// <param name="id">Unique identifier of the customer.</param>
    /// <returns>CustomerDto object if found.</returns>
    /// <response code="200">Customer found and returned successfully.</response>
    /// <response code="404">Customer with the provided identifier does not exist.</response>
    /// <response code="401">User is not authorized.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CustomerDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response<CustomerDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Response<CustomerDto>>> GetById(int id)
    {
        return await customerService.GetById(id);
    }

    /// <summary>
    ///     Get a customer by their user identifier.
    /// </summary>
    /// <param name="userId">Unique identifier of the user.</param>
    /// <returns>CustomerDto object if found.</returns>
    /// <response code="200">Customer found and returned successfully.</response>
    /// <response code="404">Customer with the provided user identifier does not exist.</response>
    /// <response code="401">User is not authorized.</response>
    [HttpGet("user/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CustomerDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response<CustomerDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Response<CustomerDto>>> GetByUserId(int userId)
    {
        return await customerService.GetByUserId(userId);
    }

    /// <summary>
    ///     Update an existing customer.
    /// </summary>
    /// <param name="id">Unique identifier of the customer to update.</param>
    /// <param name="customer">CustomerDto object containing updated info.</param>
    /// <returns>A boolean value indicating success.</returns>
    /// <response code="200">Customer updated successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    /// <response code="404">Customer with the provided identifier does not exist.</response>
    /// <response code="401">User is not authorized.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<bool>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<bool>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response<bool>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Response<bool>>> Update(int id, [FromBody] CustomerDto customer)
    {
        return await customerService.Update(id, customer);
    }
}