namespace OneBooker.Modules.Users.Application.Common.Services;

public interface IPasswordHashService
{
    Task<string> Hash(string password);

    Task<bool> Verify(string expected, string actual);
}