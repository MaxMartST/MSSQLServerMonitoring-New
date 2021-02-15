using MSSQLServerMonitoring.Domain.QueryModel;
using MSSQLServerMonitoring.Infrastructure.RepositoryBase;

namespace MSSQLServerMonitoring.Infrastructure.Data.QueryModel
{
    public class QueryRepository : RepositoryBase<Query>, IQueryRepository
    {
        public QueryRepository(RepositoryContext ctx) : base(ctx)
        {
        }
    }
}
