using OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using System.Security.Cryptography;

namespace OneBooker.Modules.Users.Infrastructure.RandomGenerator;

public class TokenGenerator : ITokenGenerator, ITransientService
{
    private static readonly char[] Characters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

    public string GenerateRandomToken(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Token length must be greater than 0.", nameof(length));
        }

        byte[] randomBytes = RandomNumberGenerator.GetBytes(length);

        char[] tokenChars = new char[length];

        for (int i = 0; i < length; i++)
        {
            int index = randomBytes[i] % Characters.Length;
            tokenChars[i] = Characters[index];
        }

        return new string(tokenChars);
    }
}