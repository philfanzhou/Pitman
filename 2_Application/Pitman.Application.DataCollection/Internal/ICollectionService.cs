using System;

namespace Pitman.Application.DataCollection
{
    internal interface ICollectionService
    {
        ServiceStatus Status { get; }

        bool IsWorkingTime(DateTime now);

        void Start();

        void Stop();
    }
}
