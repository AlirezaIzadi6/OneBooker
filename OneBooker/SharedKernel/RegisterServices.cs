using Mapster;
using OneBooker.SharedKernel.Services.Email;
using System.Reflection;

namespace OneBooker.SharedKernel;

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