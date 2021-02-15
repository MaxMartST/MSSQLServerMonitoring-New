using Microsoft.Extensions.DependencyInjection;

namespace MSSQLServerMonitoring.Infrastructure.Service.Adupter
{
    public static class ServiceAdupterBuildings
    {
        public static IServiceCollection AddAdupter(this IServiceCollection services)
        {
            return services.AddScoped<ISQLServerService, SQLServerConnectorServiceAdupter>();
        }
    }
}
