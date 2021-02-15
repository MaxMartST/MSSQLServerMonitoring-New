using MSSQLServerMonitoring.Domain.QueryModel;
using MSSQLServerMonitoring.Domain.UserModel;

namespace MSSQLServerMonitoring.Infrastructure.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IQueryRepository Query { get; }
        void Save();
    }
}
