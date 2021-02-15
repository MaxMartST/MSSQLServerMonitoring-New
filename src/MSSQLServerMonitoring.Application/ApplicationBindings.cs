using Microsoft.Extensions.DependencyInjection;
using MSSQLServerMonitoring.Application.RawDataDownload;

namespace MSSQLServerMonitoring.Application
{
    public static class ApplicationBindings
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddScoped<SQLRawDataDownload>();
        }
    }
}
