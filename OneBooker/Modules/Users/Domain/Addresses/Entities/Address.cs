using OneBooker.Shared.Entities;

namespace OneBooker.Modules.Users.Domain.Addresses.Entities;

public class Address : BaseEntity<int>
{
    public string Title { get; set; }

    public int CityId { get; set; }

    public string Line1 { get; set; }

    public string Line2 { get; set; }

    public string PostalCode { get; set; }
}