using System;
using System.Collections.Generic;
using System.Timers;

namespace Pitman.Application.DataCollection
{
    public class CollectionServiceManager
    {
        /// <summary>
        /// 服务控制timer，每30秒刷新一次
        /// </summary>
        private readonly Timer ServiceStatusCheckTimer = new Timer(30000);

        private readonly CollectionServiceContainer _serviceContainer = 
            new CollectionServiceContainer();

        #region Singleton
        private static CollectionServiceManager _instance = new CollectionServiceManager();

        public static CollectionServiceManager Instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        private CollectionServiceManager()
        {
            // 启动服务观察timer
            ServiceStatusCheckTimer.Elapsed += ServiceStatusCheckTimer_Elapsed;
            ServiceStatusCheckTimer.Enabled = true;
            ServiceStatusCheckTimer.Start();
        }

        public IEnumerable<string> GetAllServiceName()
        {
            return _serviceContainer.Services.Keys;
        }

        public string GetStatus(string serviceName)
        {
            if (_serviceContainer.Services.ContainsKey(serviceName))
            {
                return _serviceContainer.Services[serviceName].Status.ToString();
            }
            else
            {
                return ServiceStatus.Unknown.ToString();
            }
        }

        private void ServiceStatusCheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ServiceStatusCheckTimer.Enabled = false;

            DateTime now = DateTime.Now;
            foreach (var service in _serviceContainer.Services.Values)
            {
                if (service.IsWorkingTime(now))
                {
                    service.Start();
                }
                else
                {
                    service.Stop();
                }
            }

            ServiceStatusCheckTimer.Enabled = true;
        }
    }
}
