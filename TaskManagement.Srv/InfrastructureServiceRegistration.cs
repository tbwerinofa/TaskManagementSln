using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Logging;
using TaskManagement.Srv.Logging;

namespace TaskManagement.Srv;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}

