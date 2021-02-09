using MSSQLServerMonitoring.Domain.UserModel;
using MSSQLServerMonitoring.Infrastructure.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSSQLServerMonitoring.Infrastructure.Data.UserModel
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext ctx) : base(ctx)
        {
        }
    }
}
