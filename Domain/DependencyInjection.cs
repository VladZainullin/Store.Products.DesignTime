using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<TimeProvider>(static _ => TimeProvider.System);
        
        return services;
    }
}