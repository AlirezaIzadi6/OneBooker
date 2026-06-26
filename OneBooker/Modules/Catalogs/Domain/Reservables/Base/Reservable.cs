using OneBooker.SharedKernel.Entities;

namespace OneBooker.Modules.Catalogs.Domain.Reservables.Base;

public class Reservable : BaseEntity<int>
{
    public int CatalogId { get; set; }

    public OccuranceTime TimeTable { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}