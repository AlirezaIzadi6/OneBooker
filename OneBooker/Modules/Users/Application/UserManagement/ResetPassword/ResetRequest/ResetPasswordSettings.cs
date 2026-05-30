namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public record ResetPasswordSettings
{
    public string ResetPasswordUrl { get; init; }
    public uint ExpirationMinutes { get; init; }
}