using System.ComponentModel.DataAnnotations;

namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public class ResetPasswordRequest
{
    [Required, EmailAddress]
    public string Email { get; init; }
}