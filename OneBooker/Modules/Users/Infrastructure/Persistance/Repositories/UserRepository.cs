using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

public class UserRepository(UsersDbContext context) : IUserRepository, IScopedService
{
    public async Task<User> GetByIdAsync(int id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await context.Users.FirstOrDefaultAsync(
            u => u.NormalizedUsername.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await context.Users.FirstOrDefaultAsync(
            u => u.NormalizedEmail.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<User> GetByNationalCodeAsync(string nationalCode)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.NationalCode == nationalCode);
    }

    public async Task<bool> IsUsernameDuplicate(string username)
    {
        return await context.Users.AnyAsync(
            u => u.NormalizedUsername.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<bool> IsEmailDuplicate(string email)
    {
        return await context.Users.AnyAsync(u => u.NormalizedEmail.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<bool> IsNationalCodeDuplicate(string nationalCode)
    {
        return await context.Users.AnyAsync(u => u.NationalCode == nationalCode);
    }

    public async Task<int> CreateUser(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user.Id;
    }

    public async Task UpdateUser(User user)
    {
        context.Users.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}