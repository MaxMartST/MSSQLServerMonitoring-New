using MSSQLServerMonitoring.Infrastructure.Data;

namespace MSSQLServerMonitoring.Infrastructure.Factories
{
    public interface IRepositoryContextFactory
    {
        RepositoryContext CreateDbContext(string connectionString);
    }
}
