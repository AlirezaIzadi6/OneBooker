using OneBooker.Modules.Users.Application.Login;

namespace OneBooker.Modules.Users.Infrastructure.IdentityManagement;

public record JwtResponse(string AccessKey) : ILoginResult;