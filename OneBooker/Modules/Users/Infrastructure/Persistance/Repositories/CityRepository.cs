using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

public class CityRepository(UsersDbContext context) : ICityRepository, IScopedService
{
    public async Task<int> Create(City city)
    {
        await context.Cities.AddAsync(city);
        return city.Id;
    }

    public Task Update(City city)
    {
        context.Cities.Update(city);
        return Task.CompletedTask;
    }

    public Task Delete(City city)
    {
        context.Cities.Remove(city);
        return Task.CompletedTask;
    }

    public async Task<City> FindById(int id)
    {
        return await context.Cities.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<City> FindByName(string name, int provinceId)
    {
        return await context.Cities.FirstOrDefaultAsync(c => c.Name == name && c.ProvinceId == provinceId);
    }

    public async Task<ICollection<City>> ListByProvince(int provinceId)
    {
        return await context.Cities.Where(c => c.ProvinceId == provinceId).ToListAsync();
    }

    public async Task<bool> IsNameDuplicate(string name, int provinceId)
    {
        return await context.Cities.AnyAsync(c => c.Name == name && c.ProvinceId == provinceId);
    }
}
