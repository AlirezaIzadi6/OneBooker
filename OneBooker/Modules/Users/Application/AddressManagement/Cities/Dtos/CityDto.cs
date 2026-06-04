namespace OneBooker.Modules.Users.Application.AddressManagement.Cities.Dtos;

public record CityDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int ProvinceId { get; init; }
    public bool IsActive { get; init; }
}
