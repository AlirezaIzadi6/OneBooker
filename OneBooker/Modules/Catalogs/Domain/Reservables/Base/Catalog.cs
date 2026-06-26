using OneBooker.SharedKernel.Entities;
using System.ComponentModel.DataAnnotations;

namespace OneBooker.Modules.Catalogs.Domain.Reservables.Base;

public class Catalog : BaseEntity<int>
{
    [MaxLength(128)]
    public string Title { get; set; }

    [MaxLength(4096)]
    public string Description { get; set; }

    public int AddressId { get; set; }

    public int ProviderId { get; set; }
}