using System.ComponentModel.DataAnnotations;

namespace OneBooker.Modules.Users.Application.Customers.Dtos;

// TODO: Add input validation.
public record CustomerDto
{
    public int Id { get; init; }

    public string PhoneNumber { get; init; }

    public int UserId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [Length(10, 10)]
    [RegularExpression(
        @"^\d{10}$",
        ErrorMessage = "National code must be exactly 10 digits.")]
    public string NationalCode { get; set; }

    public AddressDto Address { get; init; }
}