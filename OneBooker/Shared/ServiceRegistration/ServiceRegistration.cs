using OneBooker.Shared.ServiceRegistration.Interfaces;

namespace OneBooker.Shared.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterMarkedServices(this IServiceCollection services)
    {
        services.Scan(
            scan => scan
                .FromApplicationDependencies(
                    a => a.FullName.Contains(nameof(OneBooker)))
                // Singleton
                .AddClasses(cls => cls.AssignableTo<ISingletonService>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
                // Scoped
                .AddClasses(cls => cls.AssignableTo<IScopedService>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime()
                // Transient
                .AddClasses(cls => cls.AssignableTo<ITransientService>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime());

        return services;
    }
}