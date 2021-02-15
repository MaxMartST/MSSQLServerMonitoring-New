using MSSQLServerMonitoring.Domain.QueryModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Application.RawDataDownload
{
    public interface ISQLRawDataDownload
    {
        List<Query> FilterOutNewSQLServerRequests();
    }
}
