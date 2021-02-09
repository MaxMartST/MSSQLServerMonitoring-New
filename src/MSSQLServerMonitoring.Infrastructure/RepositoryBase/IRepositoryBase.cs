using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.RepositoryBase
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetOnCondition(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
