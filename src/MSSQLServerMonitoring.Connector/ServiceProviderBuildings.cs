using Microsoft.Extensions.DependencyInjection;
using MSSQLServerMonitoring.Connector.ConnectorServices;

namespace MSSQLServerMonitoring.Connector
{
    public static class ServiceProviderBuildings
    {
        public static IServiceCollection AddMSSQLServerConnector(this IServiceCollection services, ConfigureMSSQLServerConnectorComponent configuration)
        {
            return services
                .AddSingleton(configuration)
                .AddScoped<IMSSQLServerService, MSSQLServerService>();
        }
    }
}
