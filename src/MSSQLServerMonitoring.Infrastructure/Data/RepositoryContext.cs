using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MSSQLServerMonitoring.Domain.HangFireModel;
using MSSQLServerMonitoring.Domain.QueryModel;
using MSSQLServerMonitoring.Domain.UserModel;
using MSSQLServerMonitoring.Infrastructure.Clock;
using MSSQLServerMonitoring.Infrastructure.Data.HangFireModel.EntityConfigurations;
using MSSQLServerMonitoring.Infrastructure.Data.QueryModel.EntityConfigurations;
using MSSQLServerMonitoring.Infrastructure.Data.UserModel.EntityConfigurations;
using System;
using System.Linq;

namespace MSSQLServerMonitoring.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        private readonly IClock _clock;

        public RepositoryContext(DbContextOptions<RepositoryContext> options, IClock clock) : base(options)
        {
            _clock = clock;
        }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Query> Query { get; set; }
        public DbSet<HangFireCounter> HangFireCounter { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new QueryMap());
            builder.ApplyConfiguration(new HangFireCounterMap());

            foreach (var property in builder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()))
            {
                if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                {
                    property.SetColumnType("decimal(19, 4)");
                }
                else if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v,
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));

                    if (property.ValueGenerated != ValueGenerated.Never)
                    {
                        property.SetValueGeneratorFactory((_, __) => new DateTimeNowGenerator(_clock));
                    }
                }
            }
        }
    }
}
