using Microsoft.AspNetCore.Mvc;
using MSSQLServerMonitoring.Application.RawDataDownload;
using MSSQLServerMonitoring.Domain.QueryModel;
using MSSQLServerMonitoring.Infrastructure.RepositoryWrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Api.Controllers
{
    [Route("api/[controller]")]
    public class QueriesController : Controller
    {
        private readonly SQLRawDataDownload _sQLRawDataDownload;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public QueriesController(SQLRawDataDownload sQLRawDataDownload, IRepositoryWrapper repositoryWrapper)
        {
            _sQLRawDataDownload = sQLRawDataDownload;
            _repositoryWrapper = repositoryWrapper;
        }
        [Route("GetAllQueries")]
        [HttpGet]
        public async Task<List<Query>> ListAll()
        {
            return await _repositoryWrapper.Query.GetAll();
        }

        [Route("GetDataServer")]
        [HttpGet]
        public List<Query> GetDataServer()
        {

            return _sQLRawDataDownload.FilterOutNewSQLServerRequests();
        }
    }
}
