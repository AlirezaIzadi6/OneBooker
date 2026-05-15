using Microsoft.AspNetCore.Mvc;
using OneBooker.Modules.Users.Application.UserManagement.ChangePassword;
using OneBooker.Modules.Users.Application.UserManagement.Login;
using OneBooker.Modules.Users.Application.UserManagement.Registration;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

/// <summary>
/// Manage system users.
/// </summary>
[ApiController]
[Route("api/v{versioning:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class UserManagementController(IUserRegistrationService registrationService, IUserLoginService loginService, IChangePasswordService changePasswordService) : ControllerBase
{
    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="request">RegistrationRequest object containing new user info.</param>
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
    /// <param name="request">LoginRequest object containing user's credentials.</param>
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

    /// <summary>
    /// Update user password.
    /// </summary>
    /// <param name="request">ChangePasswordRequest object containing old and new password.</param>
    /// <returns>A boolean value showing request success.></returns>
    /// <response code="200">Password updated successfully.</response>
    /// <response code="400">User does not exist or old password is not correct.</response>
    [HttpPost("change-password")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response<bool>>> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        return await changePasswordService.ChangePassword(request);
    }
}