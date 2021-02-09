using System;
using System.Collections.Generic;
using System.Text;

namespace MSSQLServerMonitoring.Infrastructure.Clock
{
    class ExampleClock : IClock
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }

        public DateTime Today()
        {
            return DateTime.UtcNow.Date;
        }
    }
}
