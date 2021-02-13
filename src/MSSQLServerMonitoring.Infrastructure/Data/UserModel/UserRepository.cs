using MSSQLServerMonitoring.Domain.UserModel;
using MSSQLServerMonitoring.Infrastructure.RepositoryBase;

namespace MSSQLServerMonitoring.Infrastructure.Data.UserModel
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext ctx) : base(ctx)
        {
        }
    }
}
