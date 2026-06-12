using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.Customers.Create;

public interface ICreateCustomerService
{
    Task<Response<int>> CreateCustomer(CustomerDto customer);
}