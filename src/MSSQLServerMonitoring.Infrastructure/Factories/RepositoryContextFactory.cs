using Microsoft.EntityFrameworkCore;
using MSSQLServerMonitoring.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSSQLServerMonitoring.Infrastructure.Factories
{
	public class RepositoryContextFactory : IRepositoryContextFactory
	{
		public RepositoryContext CreateDbContext(string connectionString)
		{
			var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
			optionsBuilder.UseSqlServer(connectionString);

			return new RepositoryContext(optionsBuilder.Options);
		}
	}
}
