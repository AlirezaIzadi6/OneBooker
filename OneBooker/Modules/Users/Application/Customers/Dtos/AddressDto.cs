namespace OneBooker.Modules.Users.Application.Customers.Dtos;

// TODO: Add input validation.
public record AddressDto
{
    public string Title { get; init; }

    public int CityId { get; init; }

    public string Line1 { get; init; }

    public string Line2 { get; init; }

    public string PostalCode { get; init; }
}