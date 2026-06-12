using OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
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

        byte[] bytes = Encoding.UTF8.GetBytes(original);
        byte[] hashBytes = SHA256.HashData(bytes);

        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }
}