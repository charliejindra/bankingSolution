using System;
using System.Collections.Generic;
using System.Text;

namespace bankingDomain
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }

    }
}
