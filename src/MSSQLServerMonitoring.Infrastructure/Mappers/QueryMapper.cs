﻿using MSSQLServerMonitoring.Connector.EventMSSQLServerModel;
using MSSQLServerMonitoring.Domain.QueryModel;
using System.Collections.Generic;
using System.Linq;

namespace MSSQLServerMonitoring.Infrastructure.Mappers
{
    public static class QueryMapper
    {
        public static Query Map(this EventMSSQLServer eventMSSQLServer)
        {
            if (eventMSSQLServer == null)
            {
                return null;
            }

            return new Query
            {
                TimeStamp = eventMSSQLServer.TimeStamp,
                AttachActivityId = eventMSSQLServer.AttachActivityId,
                EventName = eventMSSQLServer.EventName,
                PackageName = eventMSSQLServer.PackageName,
                ClientHn = eventMSSQLServer.ClientHn,
                ClientAppName = eventMSSQLServer.ClientAppName,
                NtUserName = eventMSSQLServer.NtUserName,
                DatabaseId = eventMSSQLServer.DatabaseId,
                DatabaseName = eventMSSQLServer.DatabaseName,
                Statement = eventMSSQLServer.Statement,
                Duration = eventMSSQLServer.Duration,
                CpuTime = eventMSSQLServer.CpuTime,
                PhysicalReads = eventMSSQLServer.PhysicalReads,
                LogicalReads = eventMSSQLServer.LogicalReads,
                Writes = eventMSSQLServer.Writes,
                RowCount = eventMSSQLServer.RowCount,
                SqlText = eventMSSQLServer.SqlText
            };
        }
        public static List<Query> Map(this IEnumerable<EventMSSQLServer> eventMSSQLServer)
        {
            return eventMSSQLServer == null ? new List<Query>() : eventMSSQLServer.ToList().ConvertAll(Map);
        }
    }
}
