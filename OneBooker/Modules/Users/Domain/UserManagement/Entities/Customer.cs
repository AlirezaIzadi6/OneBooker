using OneBooker.Shared.Entities;

namespace OneBooker.Modules.Users.Domain.UserManagement.Entities;

public class Customer : BaseEntity<int>
{
    public string PhoneNumber { get; set; }

    public int AddressId { get; set; }
}