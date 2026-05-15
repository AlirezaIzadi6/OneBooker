namespace OneBooker.Modules.Users.Application.AddressManagement.Countries.Dtos;

public record CountryDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public bool IsActive { get; init; }
}