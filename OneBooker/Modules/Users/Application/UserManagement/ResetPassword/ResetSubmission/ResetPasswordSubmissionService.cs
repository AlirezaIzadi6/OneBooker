using OneBooker.Modules.Users.Application.Common.Extentions;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.SharedKernel.Responses.ServiceResponse;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;
using OneBooker.SharedKernel.Services.Globalization;

namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetSubmission;

public class ResetPasswordSubmissionService(
    ITokenRepository tokens,
    IUserRepository users,
    IGlobalizationService globalizationService,
    IHashGenerator hashGenerator,
    IPasswordHashService passwordHashService) : IResetPasswordSubmissionService, IScopedService
{
    public async Task<Response<bool>> SubmitResetRequest(ResetPasswordSubmissionRequest request)
    {
        string hashedToken = hashGenerator.HashString(request.ResetPasswordToken);
        ResetPasswordToken token = await tokens.FindToken(hashedToken);
        if (token is null || token.ExpirationTime < DateTime.UtcNow)
        {
            return Response<bool>.Fail(globalizationService.InvalidInputError(nameof(request.ResetPasswordToken)));
        }

        User user = await users.GetByIdAsync(token.UserId);
        if (user.Email != request.Email)
        {
            return Response<bool>.Fail(globalizationService.InvalidInputError(nameof(request.Email)));
        }

        await tokens.DeleteExistingTokensFor(user.Id);

        string newPasswordHash = await passwordHashService.Hash(request.NewPassword);
        user.PasswordHash = newPasswordHash;
        await users.UpdateUser(user);

        return Response<bool>.Success(true);
    }
}