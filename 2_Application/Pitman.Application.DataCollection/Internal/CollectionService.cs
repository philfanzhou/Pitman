using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pitman.Application.DataCollection
{
    internal abstract class CollectionService : ICollectionService
    {
        private ServiceStatus _status = ServiceStatus.Stopped;
        private DateTime _startTime = DateTime.MinValue;
        private DateTime _stopTime = DateTime.MinValue;

        protected Progress _progress;

        public void Heartbeat()
        {
            if (_status == ServiceStatus.Running)
            {
                return;
            }

            if (IsWorkingTime(DateTime.Now))
            {
                Start();
            }
        }

        protected abstract bool IsWorkingTime(DateTime now);

        private void Start()
        {
            if (_status == ServiceStatus.Running)
            {
                return;
            }

            _status = ServiceStatus.Running;
            _startTime = DateTime.Now;

            Action action = () =>
            {
                DoWork();
                Stop();
            };

            Task tast = new Task(action);
            tast.Start();
        }

        protected virtual void Stop()
        {
            if(_status == ServiceStatus.Stopped)
            {
                return;
            }

            _status = ServiceStatus.Stopped;
            _stopTime = DateTime.Now;
        }

        protected abstract void DoWork();

        #region ICollectionService Members
        public abstract string ServiceName { get; }

        public ServiceStatus Status
        {
            get { return _status; }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
        }

        public TimeSpan ElapsedRuntime
        {
            get
            {
                return _status == ServiceStatus.Stopped ? TimeSpan.Zero : DateTime.Now - _startTime;
            }
        }

        public double Progress
        {
            get
            {
                return _progress == null ? 0 : _progress.Value;
            }
        }

        public string GetStatusReport()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
