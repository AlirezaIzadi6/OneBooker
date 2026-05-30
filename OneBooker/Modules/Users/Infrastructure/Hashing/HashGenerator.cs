using OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace OneBooker.Modules.Users.Infrastructure.Hashing;

public class HashGenerator : IHashGenerator, ITransientService
{
    public string HashString(string original)
    {
        if (string.IsNullOrWhiteSpace(original))
        {
            return string.Empty;
        }

        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(original);
        var hashBytes = sha256.ComputeHash(bytes);

        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }
}