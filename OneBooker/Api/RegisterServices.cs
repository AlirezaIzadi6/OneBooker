using OneBooker.Api.Middlewares;

namespace OneBooker.Api;

public static class RegisterServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<AuthMiddleware>();

        return services;
    }
}