using OneBooker.Shared.Responses.ServiceResponse;

namespace OneBooker.Modules.Users.Application.Login;

public interface IUserLoginService
{
    Task<Response<ILoginResult>> LoginAsync(LoginRequest request);
}