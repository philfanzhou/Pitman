using System;

namespace Pitman.Application.MarketData
{
    public interface IDataCollectionService
    {
        ServiceStatus Status { get; }

        bool IsWorkingTime(DateTime now);

        void Start();

        void Stop();
    }

    public enum ServiceStatus
    {
        Unknown = 0,

        Stopped = 1,

        Running = 2
    }
}
