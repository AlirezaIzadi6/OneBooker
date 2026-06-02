using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
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
                    };
                });

        services.AddAuthorization(
            options =>
            {
                options.AddPolicy(
                    "OnlyAdmin",
                    policy =>
                    {
                        policy.RequireClaim("UserName", "admin"); // TODO: Add a more reliable policy.
                    });
            });

        return services;
    }
}