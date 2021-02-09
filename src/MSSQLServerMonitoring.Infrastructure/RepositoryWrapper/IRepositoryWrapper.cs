using MSSQLServerMonitoring.Domain.UserModel;

namespace MSSQLServerMonitoring.Infrastructure.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}
