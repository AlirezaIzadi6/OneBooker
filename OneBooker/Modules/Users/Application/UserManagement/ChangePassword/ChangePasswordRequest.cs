using System.Text.Json.Serialization;

namespace OneBooker.Modules.Users.Application.UserManagement.ChangePassword;

public record ChangePasswordRequest
{
    [JsonIgnore]
    public int UserId { get; set; }
    public string OldPassword { get; init; }
    public string NewPassword { get; init; }
}