using OneBooker.Modules.Users.Domain.UserManagement.Entities;

namespace OneBooker.Modules.Users.Application.Common.Repositories;

public interface ICustomerRepository
{
    Task<int> Create(Customer customer);
    Task Update(Customer customer);

    Task<Customer> FindById(int id);
    Task<Customer> FindByUserId(int userId);
    Task<Customer> FindByPhoneNumber(string phoneNumber);

    Task<bool> IsPhoneNumberDuplicate(string phoneNumber);
}