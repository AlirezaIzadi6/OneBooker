using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace OneBooker.Modules.Users.Domain.UserManagement.Entities;

public class Customer : BaseEntity<int>
{
    [MaxLength(11)]
    public string PhoneNumber { get; set; }

    public int AddressId { get; set; }

    public int UserId { get; set; }

    public Address Address { get; set; }
}