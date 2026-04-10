using OneBooker.Shared.Responses;

namespace OneBooker.Modules.Users.Application.Registration;

public interface IUserRegistrationService
{
    Task<Response<bool>> RegisterUser(RegistrationRequest request);
}