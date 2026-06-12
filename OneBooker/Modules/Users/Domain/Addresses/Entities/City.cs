using OneBooker.SharedKernel.Entities;

namespace OneBooker.Modules.Users.Domain.Addresses.Entities;

public class City : BaseEntity<int>
{
    public string Name { get; set; }

    public int ProvinceId { get; set; }

    public bool IsActive { get; set; }
}