using Microsoft.EntityFrameworkCore;
using MSSQLServerMonitoring.Domain.HangFireModel;
using MSSQLServerMonitoring.Domain.UserModel;
using System;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.Data
{
    public static class DBInitializer
    {
		public async static Task Initialize(RepositoryContext context)
		{
			await context.Database.MigrateAsync();
			//Database.MigrateAsync() - накатывает на базу все миграции, которых еще нет в базе.
			//И если это первый вызов, когда базы еще нет, то создает ее.

			var userCount = await context.User.CountAsync().ConfigureAwait(false);
			var hangFireCount = await context.HangFireCounter.CountAsync().ConfigureAwait(false);

			if (userCount == 0)
			{
				context.User.Add(new User()
				{
					Login = "admin",
					Password = "admin",
					Email = "serverAdmin@gmail.com",
					isAdmin = true
				});

				await context.SaveChangesAsync().ConfigureAwait(false);
			}

			if (hangFireCount == 0)
			{
				context.HangFireCounter.Add(new HangFireCounter()
				{
					Id = 1,
					Counter = 0,
					Limit = 3
				});

				await context.SaveChangesAsync().ConfigureAwait(false);
			}
		}
	}
}
