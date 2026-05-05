using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Application.Common.Services;
using OneBooker.Modules.Users.Application.Contracts.Repositories;
using OneBooker.Modules.Users.Application.Login;
using OneBooker.Modules.Users.Application.Registration;
using OneBooker.Modules.Users.Infrastructure.Hashing;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using OneBooker.Modules.Users.Infrastructure.Persistance;
using OneBooker.Modules.Users.Infrastructure.Persistance.Repositories;

namespace OneBooker.Modules.Users;

public static class RegisterServices
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration config)
    {
        // Infrastructure:
        // Persistance:
        services.AddDbContext<UsersDbContext>(
            options => options.UseSqlServer(config.GetConnectionString("defaultConnection")));

        // Password hashing:
        services.AddScoped<IPasswordHasher<object>, PasswordHasher<object>>();
        services.AddScoped<IPasswordHashService, HashService>();

        // Jwt service:
        services.AddScoped<IIdentityManagerService, JwtManagerService>();

        // Repositories:
        services.AddScoped<IUserRepository, UserRepository>();

        // Use cases:
        services.AddScoped<IUserRegistrationService, UserRegistrationService>();
        services.AddScoped<IUserLoginService, UserLoginService>();

        // Configuration:
        services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));

        return services;
    }
}