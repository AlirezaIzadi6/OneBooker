using OneBooker.Modules.Users.Domain.UserManagement.Entities;

namespace OneBooker.Modules.Users.Application.Common.Repositories;

public interface ITokenRepository
{
    Task<ResetPasswordToken> FindToken(string hashedToken);

    Task<long> Create(ResetPasswordToken token);
    Task DeleteExistingTokensFor(int userId);
}