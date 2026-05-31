using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.Common.Repositories;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

public class TokenRepository(UsersDbContext context) : ITokenRepository, IScopedService
{
    public async Task<ResetPasswordToken> FindToken(string hashedToken)
    {
        return await context.Tokens.FirstOrDefaultAsync(t => t.HashedToken == hashedToken);
    }

    public async Task<long> Create(ResetPasswordToken token)
    {
        context.Tokens.Add(token);
        await context.SaveChangesAsync();
        return token.Id;
    }

    public async Task DeleteExistingTokensFor(int userId)
    {
        await context.Tokens.Where(t => t.UserId == userId).ExecuteDeleteAsync();
    }
}