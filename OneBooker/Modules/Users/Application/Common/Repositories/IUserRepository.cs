using OneBooker.Modules.Users.Domain.UserManagement.Entities;

namespace OneBooker.Modules.Users.Application.Contracts.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByNationalCodeAsync(string nationalCode);

    Task<bool> IsUsernameDuplicate(string username);
    Task<bool> IsEmailDuplicate(string email);
    Task<bool> IsNationalCodeDuplicate(string nationalCode);

    Task<int> CreateUser(User user);
    Task UpdateUser(User user);
}