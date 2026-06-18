using OneBooker.Modules.Users.Domain.Addresses.Entities;

namespace OneBooker.Modules.Users.Application.Common.Repositories;

public interface IAddressRepository
{
    Task<int> Create(Address address);
}