using System.ComponentModel.DataAnnotations;

namespace OneBooker.Modules.Users.Application.Registration;

public record RegistrationRequest
{
    [Length(4, 32)]
    [RegularExpression(@"^[a-zA-Z0-9_]{4,32}$",
        ErrorMessage = "Username must be 4-32 characters and contain only letters, numbers, or underscore.")]
    public string UserName { get; set; }
    [Length(8, 64)]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&^#()_\-+=])[A-Za-z\d@$!%*?&^#()_\-+=]{8,}$",
        ErrorMessage = "Password must contain at least 8 characters, including uppercase, lowercase, number, and special character."
    )]
    public string Password { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [Length(10, 10)]
    [RegularExpression(@"^\d{10}$",
        ErrorMessage = "National code must be exactly 10 digits.")]
    public string NationalCode { get; set; }
}