using System;

namespace Pitman.Application.DataCollection
{
    internal interface ICollectionService
    {
        string ServiceName { get; }

        ServiceStatus Status { get; }

        DateTime StartTime { get; }

        TimeSpan ElapsedRuntime { get; }

        double Progress { get; }

        string GetStatusReport();
    }

    internal enum ServiceStatus
    {
        /// <summary>
        /// 已停止
        /// </summary>
        Stopped = 1,
        /// <summary>
        /// 运行中
        /// </summary>
        Running = 2
    }
}
