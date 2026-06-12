namespace OneBooker.Modules.Users.Application.Customers.Dtos;

// TODO: Add input validation.
public record CustomerDto
{
    public int Id { get; init; }
    public string PhoneNumber { get; init; }
    public int UserId { get; set; }

    public AddressDto Address { get; init; }
}