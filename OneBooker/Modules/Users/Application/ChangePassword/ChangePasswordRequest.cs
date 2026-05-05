namespace OneBooker.Modules.Users.Application.ChangePassword;

public record ChangePasswordRequest
{
    public string Username { get; init; }
    public string OldPassword { get; init; }
    public string NewPassword { get; init; }
}