using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pitman.Application.DataCollection
{
    internal abstract class CollectionServiceBase
    {
        private ServiceStatus _status = ServiceStatus.Stopped;

        protected DateTime LatestStartTime
        {
            get;
            private set;
        }

        protected DateTime LatestStopTime
        {
            get;
            private set;
        }

        internal void Injection(DateTime now)
        {
            if(_status == ServiceStatus.Running)
            {
                return;
            }

            if(IsWorkingTime(now))
            {
                Start(now);
            }
        }

        private void Start(DateTime now)
        {
            _status = ServiceStatus.Running;
            LatestStartTime = now;
            DoStart();
        }

        protected virtual void Stop()
        {
            if(_status == ServiceStatus.Stopped)
            {
                return;
            }

            _status = ServiceStatus.Stopped;
            LatestStopTime = DateTime.Now;
        }

        protected abstract bool IsWorkingTime(DateTime now);

        protected abstract void DoStart();
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
