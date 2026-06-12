using OneBooker.SharedKernel.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.UserManagement.Login;

public interface IUserLoginService
{
    Task<Response<ILoginResult>> LoginAsync(LoginRequest request);
}