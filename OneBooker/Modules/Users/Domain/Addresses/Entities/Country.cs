using OneBooker.SharedKernel.Entities;

namespace OneBooker.Modules.Users.Domain.Addresses.Entities;

public class Country : BaseEntity<int>
{
    public string Name { get; set; }

    public bool IsActive { get; set; }
}