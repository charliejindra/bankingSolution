using System;

namespace bankingDomain
{
    public interface ISystemTime
    {
        DateTime GetCurrent();
    }
}