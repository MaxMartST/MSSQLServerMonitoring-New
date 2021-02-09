using System;
using System.Collections.Generic;
using System.Text;

namespace MSSQLServerMonitoring.Infrastructure.Clock
{
    public interface IClock
    {
        DateTime Now();
        DateTime Today();
    }
}
