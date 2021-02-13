using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Domain.HangFireModel
{
    public interface IHangFireCounterRepository
    {
        Task<HangFireCounter> GetHangFireCounter();
        Task UpdateHangFireCounter(HangFireCounter hangFireCounter);
    }
}
