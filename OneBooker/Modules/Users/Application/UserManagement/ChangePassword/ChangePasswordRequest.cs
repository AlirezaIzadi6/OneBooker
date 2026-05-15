namespace OneBooker.Modules.Users.Application.UserManagement.ChangePassword;

public record ChangePasswordRequest
{
    public string Username { get; init; }
    public string OldPassword { get; init; }
    public string NewPassword { get; init; }
}