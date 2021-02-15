using AutoMapper;
using MSSQLServerMonitoring.Connector.ConnectorServices;
using MSSQLServerMonitoring.Connector.EventMSSQLServerModel;
using MSSQLServerMonitoring.Domain.QueryModel;
using MSSQLServerMonitoring.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.Service.Adupter
{
    public class SQLServerConnectorServiceAdupter : Profile, ISQLServerService
    {
        IMSSQLServerService _serviceMSSQLServer;
        public SQLServerConnectorServiceAdupter(IMSSQLServerService serviceMSSQLServer)
        {
            _serviceMSSQLServer = serviceMSSQLServer;
        }

        public List<Query> GetQueriesFromSQLServer(string procedureName, DateTime timeToAsk)
        {
            List<Query> queries = new List<Query>();
            List<EventMSSQLServer> ventMSSQLServers = _serviceMSSQLServer.GetNewHistoryQueriesSQLServer(procedureName, timeToAsk);//get a new history of requests


            return ventMSSQLServers.Map();
        }
    }
}
