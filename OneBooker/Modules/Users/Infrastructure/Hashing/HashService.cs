using Microsoft.AspNetCore.Identity;
using OneBooker.Modules.Users.Application.Common.Services;

namespace OneBooker.Modules.Users.Infrastructure.Hashing;

public class HashService(IPasswordHasher<object> passwordHasher) : IPasswordHashService
{
    public Task<string> Hash(string password)
    {
        string result = passwordHasher.HashPassword(null, password);
        return Task.FromResult(result);
    }
}