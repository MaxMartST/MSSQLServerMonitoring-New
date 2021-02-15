using MSSQLServerMonitoring.Domain.QueryModel;
using MSSQLServerMonitoring.Infrastructure.RepositoryWrapper;
using MSSQLServerMonitoring.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Application.RawDataDownload
{
    public class SQLRawDataDownload : ISQLRawDataDownload
    {
        ISQLServerService _sQLServerServic;
        IRepositoryWrapper _repositoryWrapper;
        public SQLRawDataDownload(ISQLServerService sQLServerServic, IRepositoryWrapper repositoryWrapper)
        {
            _sQLServerServic = sQLServerServic;
            _repositoryWrapper = repositoryWrapper;
        }
        public List<Query> FilterOutNewSQLServerRequests()
        {
            var newQueries = new List<Query>();
            DateTime regDate = DateTime.Now.AddMinutes(-1);

            var serverQueries = _sQLServerServic.GetQueriesFromSQLServer("GiveRequestsOnTime", regDate);
            var dbQueries = _repositoryWrapper.Query.GetAll().Result;

            if (dbQueries.Count == 0)
            {
                AddNewQueriesToBatabase(serverQueries);
                return serverQueries;
            }
            else
            {
                foreach (Query sQ in serverQueries)
                {
                    int index = dbQueries.FindIndex(dbQ => IdenticalRequests(sQ, dbQ));

                    if (index == -1)
                    {
                        newQueries.Add(sQ);
                    }
                }

                AddNewQueriesToBatabase(newQueries);
                return newQueries;
            }
        }
        //private List<Query> GetCompletedQuery(DateTime timeToAsk)
        //{
        //    return _sQLServerServic.GetQueriesFromSQLServer(timeToAsk);
        //}
        private bool IdenticalRequests(Query sQ, Query dbQ)
        {
            if (sQ.AttachActivityId == dbQ.AttachActivityId)
            {
                return true;
            }

            return false;
        }
        private void AddNewQueriesToBatabase(List<Query> newQueries)
        {
            if (newQueries.Count != 0)
            {
                foreach (Query query in newQueries)
                {
                    _repositoryWrapper.Query.Add(query);
                }

                _repositoryWrapper.Save();
            }
        }
    }
}
