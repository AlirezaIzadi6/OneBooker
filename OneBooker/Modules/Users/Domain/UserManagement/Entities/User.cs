using OneBooker.Shared.Entities;

namespace OneBooker.Modules.Users.Domain.UserManagement.Entities;

/// <summary>
/// The entity for the users of the service.
/// </summary>
public class User : BaseEntity<int>
{
    /// <summary>
    /// Gets or sets user's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets user's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets user's username.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets allcap string of user's username.
    /// </summary>
    public string NormalizedUsername { get; set; }

    /// <summary>
    /// Gets or sets user's email address.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// gets or sets allcap string of email address.
    /// </summary>
    public string NormalizedEmail { get; set; }

    /// <summary>
    ///Gets or sets user's national code.
    /// </summary>
    public string NationalCode { get; set; }

    /// <summary>
    /// Gets or sets hashed version of user's password.
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// Gets or sets the last <see cref="DateTime"/> user has successfully logged in.
    /// </summary>
    public DateTime LastLoginDate { get; set; }
}