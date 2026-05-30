namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public static class EmailConstants
{
    public static string Subject => "Reset password";

    public static string Body =>
        "Hi {0}\nIf you want to reset your password, please open the following link and save your new password.\nThis link will be expired in {1} minutes.\nReset password link:\n{2}";
}