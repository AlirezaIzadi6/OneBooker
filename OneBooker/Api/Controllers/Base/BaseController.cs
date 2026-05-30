using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OneBooker.Api.Controllers.Base;

public class BaseController : ControllerBase
{
    protected int? UserId
    {
        get
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdClaim, out var userId) ? userId : null;
        }
    }
}