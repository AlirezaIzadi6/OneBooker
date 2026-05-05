using OneBooker.Modules.Users.Domain.UserManagement.Entities;

namespace OneBooker.Modules.Users.Application.Login;

public interface IIdentityManagerService
{
    Task<ILoginResult> GenerateLoginResponseAsync(LoginRequest request, User user);
}