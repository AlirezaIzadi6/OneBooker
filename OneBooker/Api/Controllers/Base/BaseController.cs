using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace OneBooker.Api.Controllers.Base;

public class BaseController : ControllerBase
{
    protected int? UserId
    {
        get
        {
            var userIdClaim = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            return int.TryParse(userIdClaim, out var userId) ? userId : null;
        }
    }
}