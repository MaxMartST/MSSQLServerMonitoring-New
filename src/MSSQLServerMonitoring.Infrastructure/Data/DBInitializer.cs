using Microsoft.EntityFrameworkCore;
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

			var userCount = await context.User.CountAsync().ConfigureAwait(false);
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
		}
	}
}
