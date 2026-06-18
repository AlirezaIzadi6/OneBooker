using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Modules.Users.Domain.UserManagement.Enums;
using OneBooker.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace OneBooker.Modules.Users.Domain.UserManagement.Entities;

public class Customer : BaseEntity<int>
{
    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [StringLength(10)]
    public string NationalCode { get; set; }

    [MaxLength(11)]
    public string PhoneNumber { get; set; }

    public Gender Gender { get; set; }

    public int AddressId { get; set; }

    public int UserId { get; set; }

    public Address Address { get; set; }
}