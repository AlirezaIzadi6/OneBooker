using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

public class CountryRepository(UsersDbContext context) : ICountryRepository, IScopedService
{
    public async Task<int> Create(Country country)
    {
        await context.Countries.AddAsync(country);
        return country.Id;
    }

    public Task Update(Country country)
    {
        context.Countries.Update(country);
        return Task.CompletedTask;
    }

    public Task Delete(Country country)
    {
        context.Countries.Remove(country);
        return Task.CompletedTask;
    }

    public async Task<Country> FindById(int id)
    {
        return await context.Countries.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Country> FindByName(string name)
    {
        return await context.Countries.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<ICollection<Country>> ListAll()
    {
        return await context.Countries.ToListAsync();
    }

    public async Task<bool> IsNameDuplicate(string name)
    {
        // TODO: check with removing space characters.
        return await context.Countries.AnyAsync(c => c.Name == name);
    }
}