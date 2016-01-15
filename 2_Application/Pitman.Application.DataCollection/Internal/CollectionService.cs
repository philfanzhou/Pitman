using System;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal abstract partial class CollectionService
    {
        #region Field
        private ServiceStatus _status = ServiceStatus.Stopped;
        private DateTime _startTime = DateTime.MinValue;
        private DateTime _stopTime = DateTime.MinValue;

        protected Progress _progress;
        #endregion

        #region Property
        public abstract string ServiceName { get; }
        #endregion

        #region Public Method
        public void Heartbeat()
        {
            if (_status == ServiceStatus.Running)
            {
                return;
            }

            if (IsWorkingTime(DateTime.Now))
            {
                StartWork();
            }
        }

        public string GetStatusReport()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine(string.Format("ServiceName:{0}", this.ServiceName));
            strBuilder.AppendLine(string.Format("Status:{0}", this._status.ToString()));
            strBuilder.AppendLine(string.Format("StartTime:{0)", _startTime.ToString("yyyyMMdd hh:mm:ss")));
            if (_status == ServiceStatus.Stopped)
            {
                strBuilder.AppendLine(string.Format("StopTime:{0)", _stopTime.ToString("yyyyMMdd hh:mm:ss")));
            }
            strBuilder.AppendLine(string.Format("ElapsedTime:{0}", (DateTime.Now - _startTime).ToString("hh:mm:ss")));
            if(_status == ServiceStatus.Running && _progress != null)
            {
                strBuilder.Append(string.Format("Progess:{0}%", _progress.Value));
            }

            return strBuilder.ToString();
        }
        #endregion

        #region Private Method
        private void StartWork()
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
                Finished();
            };

            Task tast = new Task(action);
            tast.Start();
        }
        #endregion

        #region Protected Method
        protected abstract bool IsWorkingTime(DateTime now);

        protected virtual void Finished()
        {
            if(_status == ServiceStatus.Stopped)
            {
                return;
            }

            _status = ServiceStatus.Stopped;
            _stopTime = DateTime.Now;
        }

        protected abstract void DoWork();
        #endregion
    }
}
