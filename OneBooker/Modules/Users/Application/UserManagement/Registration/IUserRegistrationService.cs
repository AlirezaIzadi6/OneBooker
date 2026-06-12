using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.UserManagement.Registration;

public interface IUserRegistrationService
{
    Task<Response<int>> RegisterUser(RegistrationRequest request);
}