using MapsterMapper;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using OneBooker.SharedKernel.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.Customers.Create;

public class CreateCustomerService(
    ICustomerRepository customers,
    IGlobalizationService globalizationService,
    IMapper mapper) : ICreateCustomerService, IScopedService
{
    public async Task<Response<int>> CreateCustomer(CustomerDto customer)
    {
        Customer existingForUser = await customers.FindByUserId(customer.UserId);
        if (existingForUser != null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.DuplicateItem),
                nameof(Customer.UserId));
            return Response<int>.Fail(errorMessage);
        }

        bool isPhoneDuplicate = await customers.IsPhoneNumberDuplicate(customer.PhoneNumber);
        if (isPhoneDuplicate)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.DuplicateItem),
                nameof(Customer.PhoneNumber));
            return Response<int>.Fail(errorMessage);
        }

        //Address address = new Address

        var createdCustomer = new Customer
        {
            PhoneNumber = customer.PhoneNumber,
            UserId = customer.UserId,
        };

        int createdId = await customers.Create(createdCustomer);

        return Response<int>.Success(createdId);
    }
}