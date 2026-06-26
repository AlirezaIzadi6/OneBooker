using OneBooker.SharedKernel.Entities;

namespace OneBooker.Modules.Catalogs.Domain.Reservables.Services;

public class Specialty : BaseEntity<int>
{
    public string Title { get; set; }

    public ServiceCategory Category { get; set; }

    public string Description { get; set; }
}