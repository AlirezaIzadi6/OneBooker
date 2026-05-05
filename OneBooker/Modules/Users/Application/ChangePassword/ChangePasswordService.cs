using OneBooker.Modules.Users.Application.Common.Messages;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.Services.Globalization;

namespace OneBooker.Modules.Users.Application.ChangePassword;

public class ChangePasswordService(IUserRepository users, IGlobalizationService globalizationService, IPasswordHashService hashService) : IChangePasswordService
{
    public async Task<Response<bool>> ChangePassword(ChangePasswordRequest request)
    {
        User user = await users.GetByUsernameAsync(request.Username);

        if (user is null)
        {
            return Response<bool>.Fail(globalizationService.Localize(Messages.UserDoesNotExist));
        }

        bool isOldPasswordCorrect = await hashService.Verify(user.PasswordHash, request.OldPassword);
        if (!isOldPasswordCorrect)
        {
            return Response<bool>.Fail(globalizationService.Localize(Messages.OldPasswordIsIncorrect));
        }

        string newHashedPassword = await hashService.Hash(request.NewPassword);
        user.PasswordHash = newHashedPassword;
        await users.UpdateUser(user);

        return Response<bool>.Success(true);
    }
}