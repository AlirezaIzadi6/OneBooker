using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.UserManagement.ResetPassword.ResetRequest;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using OneBooker.Modules.Users.Infrastructure.Persistance;

namespace OneBooker.Modules.Users;

public static class RegisterServices
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration config)
    {
        // Persistance:
        services.AddDbContext<UsersDbContext>(
            options => options.UseSqlServer(config.GetConnectionString("defaultConnection")));

        // Password hashing:
        services.AddScoped<IPasswordHasher<object>, PasswordHasher<object>>();

        // Configuration:
        services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));
        services.Configure<ResetPasswordSettings>(config.GetSection(nameof(ResetPasswordSettings)));

        return services;
    }
}