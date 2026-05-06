using Microsoft.AspNetCore.Mvc;
using OneBooker.Modules.Users.Application.Login;
using OneBooker.Modules.Users.Application.Registration;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

/// <summary>
/// Manage system users.
/// </summary>
[ApiController]
[Route("api/v{versioning:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class UserManagementController(IUserRegistrationService registrationService, IUserLoginService loginService) : ControllerBase
{
    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="request"><see cref="RegistrationRequest"/> containing new user info.</param>
    /// <returns>Unique identifier of the new user if created successfully.</returns>
    /// <response code="200">New user created successfully.</response>
    /// <response code="400">Provided information are not valid.</response>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response<int>>> RegisterUser([FromBody] RegistrationRequest request)
    {
        return await registrationService.RegisterUser(request);
    }

    /// <summary>
    /// Login with user credentials.
    /// </summary>
    /// <param name="request"><see cref="LoginRequest"/> object containing user's credentials.</param>
    /// <returns>Access token if login is successful, error message otherwise.</returns>
    /// <response code="200">Login was successful.</response>
    /// <response code="401">Login credentials were incorrect.</response>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Response<ILoginResult>>> LoginUser([FromBody] LoginRequest request)
    {
        return await loginService.LoginAsync(request);
    }
}