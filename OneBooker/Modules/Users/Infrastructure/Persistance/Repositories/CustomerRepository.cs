using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

public class CustomerRepository(UsersDbContext context) : ICustomerRepository, IScopedService
{
    public async Task<int> Create(Customer customer)
    {
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
        return customer.Id;
    }

    public async Task Update(Customer customer)
    {
        context.Customers.Update(customer);
        await context.SaveChangesAsync();
    }

    public async Task<Customer> FindById(int id)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Customer> FindByUserId(int userId)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task<Customer> FindByPhoneNumber(string phoneNumber)
    {
        return await context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
    }

    public async Task<bool> IsPhoneNumberDuplicate(string phoneNumber)
    {
        return await context.Customers.AnyAsync(c => c.PhoneNumber == phoneNumber);
    }
}