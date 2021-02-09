using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSSQLServerMonitoring.Infrastructure.RepositoryWrapper
{
    public static class RepositoryWrapperBindings
    {
        public static IServiceCollection AddRepositoryWrapper(this IServiceCollection services)
        {
            return services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
