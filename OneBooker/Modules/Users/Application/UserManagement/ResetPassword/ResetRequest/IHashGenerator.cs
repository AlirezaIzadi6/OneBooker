namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public interface IHashGenerator
{
    string HashString(string original);
}