using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pitman.Application.Management
{
    public class ServiceManager
    {
        #region Singleton
        private static ServiceManager instance;

        public static ServiceManager Instance
        {
            get
            {
                if (null == instance)
                {
                    System.Threading.Interlocked.CompareExchange(ref instance, new ServiceManager(), null);
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// 服务控制timer，每30秒刷新一次
        /// </summary>
        private readonly Timer ServiceStatusCheckTimer = new Timer(30000);

        private readonly List<IDataCollectionService> serviceList = ServiceFactory.CreateAllService().ToList();

        private ServiceManager()
        {
            // 启动服务观察timer
            ServiceStatusCheckTimer.Elapsed += ServiceStatusCheckTimer_Elapsed;
            ServiceStatusCheckTimer.Enabled = true;
            ServiceStatusCheckTimer.Start();
        }

        public IEnumerable<IDataCollectionService> Services
        {
            get { return this.serviceList; }
        }

        private void ServiceStatusCheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ServiceStatusCheckTimer.Enabled = false;

            DateTime now = DateTime.Now;
            foreach(var service in serviceList)
            {
                if(service.IsWorkingTime(now))
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
