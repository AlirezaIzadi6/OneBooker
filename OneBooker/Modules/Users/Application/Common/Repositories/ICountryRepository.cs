using OneBooker.Modules.Users.Domain.Addresses.Entities;

namespace OneBooker.Modules.Users.Application.Common.Repositories;

public interface ICountryRepository
{
    Task<int> Create(Country country);
    Task Update(Country country);
    Task Delete(Country country);

    Task<Country> FindById(int id);

    Task<Country> FindByName(string name);

    Task<bool> IsNameDuplicate(string name);
}