using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Modules.Users.Application.UserManagement.Login;

public class UserLoginService(
    IUserRepository users,
    IPasswordHashService hashService,
    IIdentityManagerService identityService,
    IGlobalizationService globalizationService) : IUserLoginService, IScopedService
{
    public async Task<Response<ILoginResult>> LoginAsync(LoginRequest request)
    {
        User user = await users.GetByUsernameAsync(request.UserName);
        bool areCredentialsCorrect = user is not null && await hashService.Verify(user.PasswordHash, request.Password);
        if (!areCredentialsCorrect)
        {
            return Response<ILoginResult>.NotAuthenticated(
                globalizationService.Localize(Messages.UsernameOrPasswordIncorrect));
        }

        ILoginResult loginResult = await identityService.GenerateLoginResponseAsync(request, user);

        return Response<ILoginResult>.Success(loginResult);
    }
}