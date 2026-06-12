using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.Customers.GetOne;

public class GetCustomerService(ICustomerRepository customers, IGlobalizationService globalizationService)
    : IGetCustomerService, IScopedService
{
    public async Task<Response<CustomerDto>> GetCustomerById(int id)
    {
        Customer customer = await customers.FindById(id);
        return MapToResponse(customer);
    }

    public async Task<Response<CustomerDto>> GetCustomerByUserId(int userId)
    {
        Customer customer = await customers.FindByUserId(userId);
        return MapToResponse(customer);
    }

    private Response<CustomerDto> MapToResponse(Customer customer)
    {
        if (customer == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(Customer));
            return Response<CustomerDto>.Fail(errorMessage);
        }

        var customerDto = new CustomerDto
        {
            Id = customer.Id,
            PhoneNumber = customer.PhoneNumber,

            //AddressId = customer.AddressId,
            UserId = customer.UserId,
        };

        return Response<CustomerDto>.Success(customerDto);
    }
}