using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MSSQLServerMonitoring.Domain.UserModel;
using MSSQLServerMonitoring.Infrastructure.Data.UserModel;
using System;

namespace MSSQLServerMonitoring.Infrastructure.Data
{
    public static class DataBindings
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IUserRepository, UserRepository>();
        }

        public static IServiceCollection AddDatabase<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            return services.AddDbContext<T>(c =>
            {
                try
                {
                    c.UseLazyLoadingProxies().UseSqlServer(connectionString);
                }
                catch (Exception)
                {
                    //TODO: logger
                }
            });
        }
    }
}
