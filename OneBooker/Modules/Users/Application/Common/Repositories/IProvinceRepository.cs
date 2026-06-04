using OneBooker.Modules.Users.Domain.Addresses.Entities;

namespace OneBooker.Modules.Users.Application.Common.Repositories;

public interface IProvinceRepository
{
    Task<int> Create(Province province);
    Task Update(Province province);
    Task Delete(Province province);

    Task<Province> FindById(int id);

    Task<Province> FindByName(string name, int countryId);

    Task<ICollection<Province>> ListByCountry(int countryId);
    Task<bool> IsNameDuplicate(string name, int countryId);
}
