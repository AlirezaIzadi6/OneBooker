using System.ComponentModel.DataAnnotations;

namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetSubmission;

public record ResetPasswordSubmissionRequest
{
    [Length(40, 40)]
    public string ResetPasswordToken { get; init; }

    [EmailAddress]
    public string Email { get; init; }

    [Length(8, 64)]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&^#()_\-+=])[A-Za-z\d@$!%*?&^#()_\-+=]{8,}$",
        ErrorMessage = "Password must contain at least 8 characters, including uppercase, lowercase, number, and special character."
    )]
    public string NewPassword { get; init; }
}