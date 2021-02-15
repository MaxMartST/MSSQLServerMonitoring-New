using MSSQLServerMonitoring.Domain.QueryModel;
using MSSQLServerMonitoring.Domain.UserModel;
using MSSQLServerMonitoring.Infrastructure.Data;
using MSSQLServerMonitoring.Infrastructure.Data.QueryModel;
using MSSQLServerMonitoring.Infrastructure.Data.UserModel;

namespace MSSQLServerMonitoring.Infrastructure.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _ctx;
        private IUserRepository _user;
        private IQueryRepository _query;
        public RepositoryWrapper(RepositoryContext ctx)
        {
            _ctx = ctx;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_ctx);
                }
                return _user;
            }
        }

        public IQueryRepository Query
        {
            get
            {
                if (_query == null)
                {
                    _query = new QueryRepository(_ctx);
                }
                return _query;
            }
        }
        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
