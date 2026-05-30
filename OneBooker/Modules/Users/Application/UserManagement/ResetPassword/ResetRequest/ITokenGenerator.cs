namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public interface ITokenGenerator
{
    string GenerateRandomToken(int length);
}