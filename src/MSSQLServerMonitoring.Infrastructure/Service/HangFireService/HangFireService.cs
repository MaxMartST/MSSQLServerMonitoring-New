using MSSQLServerMonitoring.Domain.HangFireModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLServerMonitoring.Infrastructure.Service.HangFireService
{
    public class HangFireService : IHangFireService
    {
        private readonly IHangFireCounterRepository _hangFireCounterRepository;
        public HangFireService(IHangFireCounterRepository hangFireCounterRepository)
        {
            _hangFireCounterRepository = hangFireCounterRepository;
        }
        public async Task DataAnalysis()
        {
            Console.WriteLine("Analyzing requests for the last hour.");
        }

        public async Task SavingDataOrClearingBuffer()
        {
            HangFireCounter hangFireCounter = await _hangFireCounterRepository.GetHangFireCounter();

            if (hangFireCounter.Counter < hangFireCounter.Limit)
            {
                //await _sQLRawDataDownload.FilterOutNewSQLServerRequests();
                Console.WriteLine($"MSSQL server is being accessed. Counter: {hangFireCounter.Counter}, Limit: {hangFireCounter.Limit}.");
                hangFireCounter.Counter++;

                await _hangFireCounterRepository.UpdateHangFireCounter(hangFireCounter);
            }
            else
            {
                //await _eventBufferRepository.ClearEventSessionBuffer();
                Console.WriteLine($"Clearing the event session buffer. Counter: {hangFireCounter.Counter}, Limit: {hangFireCounter.Limit}.");
                hangFireCounter.Counter = 0;

                await _hangFireCounterRepository.UpdateHangFireCounter(hangFireCounter);
            }
        }
    }
}
