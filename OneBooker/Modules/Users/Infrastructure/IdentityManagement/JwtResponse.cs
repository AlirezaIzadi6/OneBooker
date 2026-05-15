using OneBooker.Modules.Users.Application.UserManagement.Login;

namespace OneBooker.Modules.Users.Infrastructure.IdentityManagement;

public record JwtResponse(string AccessKey) : ILoginResult;