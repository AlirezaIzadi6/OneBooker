namespace OneBooker.Shared;

public static class RegisterServices
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddLocalization();

        return services;
    }
}