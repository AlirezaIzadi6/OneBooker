using MapsterMapper;
using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Application.Customers.Dtos;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using OneBooker.SharedKernel.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.Customers.Update;

public class UpdateCustomerService(
    ICustomerRepository customers,
    IGlobalizationService globalizationService,
    IMapper mapper)
    : IUpdateCustomerService, IScopedService
{
    public async Task<Response<bool>> UpdateCustomer(int id, CustomerDto customer)
    {
        Customer existingCustomer = await customers.FindById(id);
        if (existingCustomer == null)
        {
            string errorMessage = string.Format(
                CultureInfo.InvariantCulture,
                globalizationService.Localize(Messages.NotFound),
                nameof(Customer));
            return Response<bool>.Fail(errorMessage);
        }

        if (existingCustomer.PhoneNumber != customer.PhoneNumber)
        {
            bool isPhoneDuplicate = await customers.IsPhoneNumberDuplicate(customer.PhoneNumber);
            if (isPhoneDuplicate)
            {
                string errorMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    globalizationService.Localize(Messages.DuplicateItem),
                    nameof(Customer));
                return Response<bool>.Fail(errorMessage);
            }
        }

        existingCustomer.PhoneNumber = customer.PhoneNumber;
        existingCustomer.Address = mapper.Map<Address>(customer.Address);
        existingCustomer.UserId = customer.UserId;

        await customers.Update(existingCustomer);

        return Response<bool>.Success(true);
    }
}