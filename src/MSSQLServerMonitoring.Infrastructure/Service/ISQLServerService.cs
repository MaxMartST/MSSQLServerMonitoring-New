using MSSQLServerMonitoring.Domain.QueryModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.Service
{
    public interface ISQLServerService
    {
        List<Query> GetQueriesFromSQLServer(string procedureName, DateTime timeToAsk);
    }
}
