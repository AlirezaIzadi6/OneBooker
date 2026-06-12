using OneBooker.SharedKernel.Entities;

namespace OneBooker.Modules.Users.Domain.Addresses.Entities;

public class Province : BaseEntity<int>
{
    public string Name { get; set; }

    public int CountryId { get; set; }

    public bool IsActive { get; set; }
}