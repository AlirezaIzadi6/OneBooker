using Microsoft.AspNetCore.Identity;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Hashing;

public class PasswordHashService(IPasswordHasher<object> passwordHasher) : IPasswordHashService, IScopedService
{
    public Task<string> Hash(string password)
    {
        string result = passwordHasher.HashPassword(null, password);
        return Task.FromResult(result);
    }

    public Task<bool> Verify(string expected, string actual)
    {
        bool passwordsMatch = passwordHasher.VerifyHashedPassword(null, expected, actual) ==
                              PasswordVerificationResult.Success;
        return Task.FromResult(passwordsMatch);
    }
}