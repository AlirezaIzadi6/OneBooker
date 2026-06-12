using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.Customers.GetOne;

public interface IGetCustomerService
{
    Task<Response<CustomerDto>> GetCustomerById(int id);
    Task<Response<CustomerDto>> GetCustomerByUserId(int userId);
}