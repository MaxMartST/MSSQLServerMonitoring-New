using Microsoft.EntityFrameworkCore;
using MSSQLServerMonitoring.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.RepositoryBase
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _ctx;
        public RepositoryBase(RepositoryContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<T>> GetAll()
        {
            return _ctx.Set<T>().ToListAsync();
        }

        public Task<List<T>> GetOnCondition(Expression<Func<T, bool>> expression)
        {
            return _ctx.Set<T>().Where(expression).ToListAsync();
        }

        public Task Add(T entity)
        {
            _ctx.Set<T>().Add(entity);

            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            _ctx.Set<T>().Update(entity);

            return Task.CompletedTask;
        }

        public Task Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
