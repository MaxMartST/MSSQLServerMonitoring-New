using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSSQLServerMonitoring.Infrastructure.Factories
{
    public static class RepositoryContextFactoryBindings
    {
        public static IServiceCollection AddRepositoryContextFactory(this IServiceCollection services)
        {
            return services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
        }
    }
}
