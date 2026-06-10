using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OneBooker.Modules.Users.Domain.UserManagement.Enums;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using System.Security.Claims;
using System.Text;

namespace OneBooker.Api.Configurations.Auth;

public static class RegisterAuthServices
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        JwtSettings authSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
        services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.SecretKey)),
                        RoleClaimType = ClaimTypes.Role
                    };
                });

        services.AddAuthorizationBuilder()
            .AddPolicy(AuthConstants.AdminPolicy,
                policy =>
                {
                    policy.RequireRole(UserRole.Admin.ToString());
                });

        return services;
    }
}