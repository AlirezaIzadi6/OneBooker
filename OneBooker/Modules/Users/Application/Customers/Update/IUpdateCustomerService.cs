using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.Customers.Update;

public interface IUpdateCustomerService
{
    Task<Response<bool>> UpdateCustomer(int id, CustomerDto customer);
}