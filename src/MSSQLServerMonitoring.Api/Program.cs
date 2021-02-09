using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MSSQLServerMonitoring.Infrastructure.Data;
using MSSQLServerMonitoring.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
			var host = BuildWebHost(args);

			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			var config = builder.Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				var factory = services.GetRequiredService<IRepositoryContextFactory>();
				using (var context = factory.CreateDbContext(config.GetConnectionString("DefaultConnection")))
				{
					await DBInitializer.Initialize(context);
				}
			}

			host.Run();
		}

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
