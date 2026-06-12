using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.InternalApis.UserManagement.Interfaces;

public interface ICustomerManagementService
{
    Task<Response<int>> Create(CustomerDto customer);

    Task<Response<bool>> Update(int id, CustomerDto customer);

    Task<Response<CustomerDto>> GetById(int id);

    Task<Response<CustomerDto>> GetByUserId(int userId);
}