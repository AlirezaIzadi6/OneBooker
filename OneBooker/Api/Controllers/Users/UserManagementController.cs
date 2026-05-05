using Microsoft.AspNetCore.Mvc;
using OneBooker.Modules.Users.Application.Login;
using OneBooker.Modules.Users.Application.Registration;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

/// <summary>
/// 
/// </summary>
/// <param name="registrationService"></param>
/// <param name="loginService"></param>
[ApiController]
[Route("api/{versioning:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class UserManagementController(IUserRegistrationService registrationService, IUserLoginService loginService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<Response<int>>> RegisterUser([FromBody] RegistrationRequest request)
    {
        return await registrationService.RegisterUser(request);
    }

    /// <summary>
    /// Login with this endpoint.
    /// </summary>
    /// <param name="request"><see cref="LoginRequest"/> object containing user's credentials.</param>
    /// <returns>Access token if login is successful, error message otherwise.</returns>
    /// <response code="200">Login was successful.</response>
    /// <response code="400">Login credentials were incorrect.</response>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Response<ILoginResult>>> LoginUser([FromBody] LoginRequest request)
    {
        return await loginService.LoginAsync(request);
    }
}