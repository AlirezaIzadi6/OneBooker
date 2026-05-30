using OneBooker.Shared.Services.Email;

namespace OneBooker.Shared;

public static class RegisterServices
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLocalization();
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));

        return services;
    }
}