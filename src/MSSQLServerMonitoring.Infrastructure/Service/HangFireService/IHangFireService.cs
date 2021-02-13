using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.Service.HangFireService
{
    public interface IHangFireService
    {
        Task SavingDataOrClearingBuffer();
        Task DataAnalysis();
    }
}
