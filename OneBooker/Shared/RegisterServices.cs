using OneBooker.Shared.Services.Globalization;

namespace OneBooker.Shared;

public static class RegisterServices
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddSingleton<IGlobalizationService, GlobalizationService>();

        return services;
    }
}