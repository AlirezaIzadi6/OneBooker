using Microsoft.AspNetCore.Mvc;
using OneBooker.Modules.Users.Application.Registration;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Api.Controllers.Users;

[ApiController]
public class UserManagementController(IUserRegistrationService registrationService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<Response<int>>> RegisterUser([FromBody] RegistrationRequest request)
    {
        return await registrationService.RegisterUser(request);
    }
}