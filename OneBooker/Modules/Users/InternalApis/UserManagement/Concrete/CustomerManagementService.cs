using OneBooker.Modules.Users.Application.Customers.Create;
using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.Modules.Users.Application.Customers.GetOne;
using OneBooker.Modules.Users.Application.Customers.Update;
using OneBooker.Modules.Users.InternalApis.UserManagement.Interfaces;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.InternalApis.UserManagement.Concrete;

public class CustomerManagementService(
    ICreateCustomerService createService,
    IUpdateCustomerService updateService,
    IGetCustomerService getService) : ICustomerManagementService, IScopedService
{
    public async Task<Response<int>> Create(CustomerDto customer)
    {
        return await createService.CreateCustomer(customer);
    }

    public async Task<Response<bool>> Update(int id, CustomerDto customer)
    {
        return await updateService.UpdateCustomer(id, customer);
    }

    public async Task<Response<CustomerDto>> GetById(int id)
    {
        return await getService.GetCustomerById(id);
    }

    public async Task<Response<CustomerDto>> GetByUserId(int userId)
    {
        return await getService.GetCustomerByUserId(userId);
    }
}