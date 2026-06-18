using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

public class AddressRepository(UsersDbContext context) : IAddressRepository, IScopedService
{
    public async Task<int> Create(Address address)
    {
        context.Addresses.Add(address);
        await context.SaveChangesAsync();
        return address.Id;
    }
}
