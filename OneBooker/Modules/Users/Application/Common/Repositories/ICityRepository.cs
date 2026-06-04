using OneBooker.Modules.Users.Domain.Addresses.Entities;

namespace OneBooker.Modules.Users.Application.Common.Repositories;

public interface ICityRepository
{
    Task<int> Create(City city);
    Task Update(City city);
    Task Delete(City city);

    Task<City> FindById(int id);

    Task<City> FindByName(string name, int provinceId);

    Task<ICollection<City>> ListByProvince(int provinceId);
    Task<bool> IsNameDuplicate(string name, int provinceId);
}
