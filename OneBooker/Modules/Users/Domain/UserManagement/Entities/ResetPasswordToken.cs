using OneBooker.SharedKernel.Entities;

namespace OneBooker.Modules.Users.Domain.UserManagement.Entities;

public class ResetPasswordToken : BaseEntity<long>
{
    public int UserId { get; set; }

    public string HashedToken { get; set; }

    public DateTime ExpirationTime { get; set; }
}