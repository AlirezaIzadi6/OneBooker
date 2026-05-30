using Microsoft.Extensions.Options;
using OneBooker.Modules.Users.Application.Common.Extentions;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.Shared.Responses.ServiceResponse;
using OneBooker.Shared.ServiceRegistration.Interfaces;
using OneBooker.Shared.Services.Email;
using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;

public class ResetPasswordRequestService(IUserRepository users, ITokenRepository tokens, IGlobalizationService globalizationService, ITokenGenerator tokenGenerator, IHashGenerator hashGenerator, IEmailService emailService, IOptions<ResetPasswordSettings> resetPasswordConfig) : IResetPasswordRequestService, IScopedService
{
    public async Task<Response<bool>> RequestReset(ResetPasswordRequest request)
    {
        User user = await users.GetByEmailAsync(request.Email);
        if (user is null)
        {
            return Response<bool>.NotFound(globalizationService.NotFoundError(nameof(User)));
        }

        await tokens.DeleteExistingTokensFor(user.Id);
        ResetPasswordSettings settings = resetPasswordConfig.Value;

        string token = tokenGenerator.GenerateRandomToken(40);
        string hashedToken = hashGenerator.HashString(token);
        var newToken = new ResetPasswordToken
        {
            UserId = user.Id,
            HashedToken = hashedToken,
            ExpirationTime = DateTime.UtcNow.AddMinutes(settings.ExpirationMinutes),
        };

        await tokens.Create(newToken);

        string resetPasswordUrl = string.Format(
            CultureInfo.InvariantCulture,
            settings.ResetPasswordUrl,
            token);
        string body = string.Format(
            CultureInfo.InvariantCulture,
            EmailConstants.Body,
            user.FirstName,
            settings.ExpirationMinutes,
            resetPasswordUrl);
        SendEmailRequest emailRequest = new SendEmailRequest
        {
            Recipients = [request.Email],
            subject = EmailConstants.Subject,
            Body = body,
        };

        emailService.SendAsync(emailRequest);

        return Response<bool>.Success(true);
    }
}