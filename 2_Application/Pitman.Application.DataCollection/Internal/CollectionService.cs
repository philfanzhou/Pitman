using Framework.Infrastructure.Log;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Pitman.Application.MarketData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal abstract class CollectionService
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
            strBuilder.AppendLine(string.Format("StartTime:{0}", _startTime.ToString("yy-MM-dd HH:mm:ss")));

            if (_status == ServiceStatus.Stopped)
            {
                strBuilder.AppendLine(string.Format("StopTime:{0}", _stopTime.ToString("yy-MM-dd HH:mm:ss")));
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
                try
                {
                    DoWork();
                }
                catch(Exception ex)
                {
                    LogHelper.Logger.WriteLine(ex.ToString(), this.ServiceName);
                }
                finally
                {
                    Finished();
                }
            };

            Task tast = new Task(action);
            tast.Start();
        }

        private IEnumerable<ISecurity> GetSecurityFromApi()
        {
            IEnumerable<ISecurity> result = null;
            int i = 0;
            do
            {
                try
                {
                    result = new SecurityInfoApi().GetAllSecurity();
                }
                finally
                {
                    i++;
                }

                // 尝试10次获取数据， 确保能够获取数据成功
                if (i > 9)
                {
                    break;
                }
            } while (result == null);

            return result;
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
            try
            {
                if (_status == ServiceStatus.Stopped)
                {
                    return;
                }

                _status = ServiceStatus.Stopped;
                _stopTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine(ex.ToString(), this.ServiceName);
            }
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

        /// <summary>
        /// 尝试从数据库或者Api获取所有Security
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<ISecurity> GetAllSecurity()
        {
            IEnumerable<ISecurity> result = null;
            try
            {
                SecurityAppService appService = new SecurityAppService();
                result = appService.GetAll();
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine(ex.ToString(), this.ServiceName);
            }

            // 如果从数据库获取数据不成功，从网页进行数据获取
            if( result == null || result.Count() <= 0)
            {
                result = GetSecurityFromApi();
            }

            return result == null ? new List<ISecurity>() : result;
        }
        #endregion
    }
}
