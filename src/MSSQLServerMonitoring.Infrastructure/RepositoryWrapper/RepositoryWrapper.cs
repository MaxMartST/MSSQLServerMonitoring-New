using MSSQLServerMonitoring.Domain.UserModel;
using MSSQLServerMonitoring.Infrastructure.Data;
using MSSQLServerMonitoring.Infrastructure.Data.UserModel;

namespace MSSQLServerMonitoring.Infrastructure.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _ctx;
        private IUserRepository _user;
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


        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
