using Mapster;
using OneBooker.Shared.Services.Email;
using System.Reflection;

namespace OneBooker.Shared;

public static class RegisterServices
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLocalization();
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

        // Setup and config Mapster.
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddMapster();

        return services;
    }
}