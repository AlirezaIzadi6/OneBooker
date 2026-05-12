using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneBooker.Api.Filters;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using OneBooker.Shared.Services.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OneBooker.Api.Middlewares;

public class AuthMiddleware(IOptions<JwtSettings> settings, IGlobalizationService globalizationService) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string authHeader = context.Request.Headers.Authorization;
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            string token = authHeader["Bearer ".Length..].Trim();
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Value.SecretKey)),
                    ValidateIssuer = true,
                    ValidIssuer = settings.Value.Issuer,
                    ValidateAudience = true,
                    ValidAudience = settings.Value.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };

                ClaimsPrincipal principal = handler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                context.User = principal;
            }
            catch (Exception)
            {
                await ReturnUnauthorized(context);
                return;
            }
        }

        await next.Invoke(context);
    }

    private async Task ReturnUnauthorized(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.ContentType = "application/json";
        string errorMessage = globalizationService.Localize(Messages.TokenIsInvalid);
        var response = new ErrorResult(errorMessage);
        await context.Response.WriteAsJsonAsync(response);
    }
}