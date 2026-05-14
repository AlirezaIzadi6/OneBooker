using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Shared.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services.Scan(
            scan => scan
                .FromApplicationDependencies(
                    a => a.FullName.Contains($"{nameof(OneBooker)}.{nameof(OneBooker.Modules)}"))
                .AddClasses(cls => cls.AssignableTo<ISingletonService>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
                .AddClasses(cls => cls.AssignableTo<IScopedService>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime()
                .AddClasses(cls => cls.AssignableTo<ITransientService>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime());

        return services;
    }
}