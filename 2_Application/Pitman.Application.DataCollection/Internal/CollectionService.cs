﻿using System;
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
        private Progress _progress;
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

            if (IsWorkingTime())
            {
                StartWork();
            }
        }

        public string GetStatusReport()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine(string.Format("ServiceName:{0}", this.ServiceName));
            strBuilder.AppendLine(string.Format("Status:{0}", this._status.ToString()));
            strBuilder.AppendLine(string.Format("StartTime:{0}", _startTime.ToString("yy-MM-dd hh:mm:ss")));

            if (_status == ServiceStatus.Stopped)
            {
                strBuilder.AppendLine(string.Format("StopTime:{0}", _stopTime.ToString("yy-MM-dd hh:mm:ss")));
                strBuilder.AppendLine(string.Format("ElapsedTime:{0}", (_stopTime - _startTime).ToString()));
            }
            else
            {
                strBuilder.AppendLine(string.Format("ElapsedTime:{0}", (DateTime.Now - _startTime).ToString()));
            }

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

            // TODO: 考虑异常处理
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
        protected DateTime StartTime
        {
            get { return this._startTime; }
        }

        protected DateTime StopTime
        {
            get { return this._stopTime; }
        }

        protected Progress Progress
        {
            get { return _progress; }
            set { _progress = value; }
        }

        protected abstract bool IsWorkingTime();

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

        /// <summary>
        /// 判断今天是否已经完成过任务
        /// </summary>
        /// <returns></returns>
        protected bool IsCompletedToday()
        {
            return DateTime.Now.Date == _startTime.Date;
        }
        #endregion
    }
}
