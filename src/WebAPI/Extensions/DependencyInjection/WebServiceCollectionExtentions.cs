using Infrastructure.Extensions.DependencyInjection;
using Application.Extensions.DependencyInjection;

namespace WebAPI.Extensions.DependencyInjection;

public static class WebServiceCollectionExtentions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IHostBuilder host, IConfiguration configuration)
    {
        // Important for IHttpContextAccessor
        services.AddHttpContextAccessor();

        // Logging
        services.AddLoggingDependencies();
        host.UseCustomSerilog();

        // Register Services
        services
            .AddApplicationDependencies()
            .AddInfrastructureDependencies(configuration);

        // API Versioning
        services.AddApiVersioningDependencies();

        return services;
    }
}
