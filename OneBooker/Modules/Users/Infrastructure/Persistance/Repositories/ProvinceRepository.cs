using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

public class ProvinceRepository(UsersDbContext context) : IProvinceRepository, IScopedService
{
    public async Task<int> Create(Province province)
    {
        await context.Provinces.AddAsync(province);
        await context.SaveChangesAsync();
        return province.Id;
    }

    public async Task Update(Province province)
    {
        context.Provinces.Update(province);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Province province)
    {
        context.Provinces.Remove(province);
        await context.SaveChangesAsync();
    }

    public async Task<Province> FindById(int id)
    {
        return await context.Provinces.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Province> FindByName(string name, int countryId)
    {
        return await context.Provinces.FirstOrDefaultAsync(p => p.Name == name && p.CountryId == countryId);
    }

    public async Task<ICollection<Province>> ListByCountry(int countryId)
    {
        return await context.Provinces.Where(p => p.CountryId == countryId).ToListAsync();
    }

    public async Task<bool> IsNameDuplicate(string name, int countryId)
    {
        return await context.Provinces.AnyAsync(p => p.Name == name && p.CountryId == countryId);
    }
}
