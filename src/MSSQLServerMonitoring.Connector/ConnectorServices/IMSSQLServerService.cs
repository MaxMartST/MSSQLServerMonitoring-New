using MSSQLServerMonitoring.Connector.EventMSSQLServerModel;
using System;
using System.Collections.Generic;

namespace MSSQLServerMonitoring.Connector.ConnectorServices
{
    public interface IMSSQLServerService
    {
        List<EventMSSQLServer> GetNewHistoryQueriesSQLServer(string procedureName, DateTime timeToAsk);
    }
}
