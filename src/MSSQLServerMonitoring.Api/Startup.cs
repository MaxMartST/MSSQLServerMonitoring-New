using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;
using MSSQLServerMonitoring.Infrastructure.Clock;
using MSSQLServerMonitoring.Infrastructure.Data;
using MSSQLServerMonitoring.Infrastructure.Factories;
using MSSQLServerMonitoring.Infrastructure.RepositoryWrapper;

namespace MSSQLServerMonitoring.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase<RepositoryContext>(Configuration.GetConnectionString("DefaultConnection"));
            services.AddFeatureManagement();
            services
                .AddControllers()
                .AddNewtonsoftJson();
            services
                .AddRepositoryWrapper()
                .AddClock()
                .AddRepositories()
                .AddRepositoryContextFactory();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MSSQLServerMonitoring.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSSQLServerMonitoring.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
