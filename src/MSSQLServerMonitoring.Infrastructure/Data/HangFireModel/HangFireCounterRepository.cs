using Microsoft.EntityFrameworkCore;
using MSSQLServerMonitoring.Domain.HangFireModel;
using MSSQLServerMonitoring.Infrastructure.Factories;
using System;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.Data.HangFireModel
{
    public class HangFireCounterRepository : IHangFireCounterRepository
    {
        private string _connectionString { get; }
        readonly IRepositoryContextFactory _contextFactory;
        public HangFireCounterRepository(string connectionString, IRepositoryContextFactory contextFactory)
        {
            _connectionString = connectionString;
            _contextFactory = contextFactory;
        }
        public async Task<HangFireCounter> GetHangFireCounter()
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                return await context.HangFireCounter.FirstAsync();
            };
        }

        public Task UpdateHangFireCounter(HangFireCounter hangFireCounter)
        {
            using (var context = _contextFactory.CreateDbContext(_connectionString))
            {
                context.HangFireCounter.Update(hangFireCounter);
                context.SaveChanges();
            };

            return Task.CompletedTask;
        }
    }
}
