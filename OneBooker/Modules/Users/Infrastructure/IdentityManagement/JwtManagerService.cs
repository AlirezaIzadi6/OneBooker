using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneBooker.Modules.Users.Application.Login;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace OneBooker.Modules.Users.Infrastructure.IdentityManagement;

public class JwtManagerService(IOptions<JwtSettings> jwtOptions) : IIdentityManagerService
{
    public async Task<ILoginResult> GenerateLoginResponseAsync(LoginRequest request, User user)
    {
        JwtSettings settings = jwtOptions.Value;
        string token = GenerateStringToken(user, settings);

        var response = new JwtResponse(token);
        return response;
    }

    private static string GenerateStringToken(User user, JwtSettings settings)
    {
        List<Claim> claims =
        [
            new(
                JwtRegisteredClaimNames.Sub,
                user.Id.ToString(CultureInfo.InvariantCulture)),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("Username", user.Username)
        ];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: settings.Issuer,
            audience: settings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(settings.ExpirationMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}