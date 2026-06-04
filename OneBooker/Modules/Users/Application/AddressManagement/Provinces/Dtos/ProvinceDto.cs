namespace OneBooker.Modules.Users.Application.AddressManagement.Provinces.Dtos;

public record ProvinceDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int CountryId { get; init; }
    public bool IsActive { get; init; }
}
