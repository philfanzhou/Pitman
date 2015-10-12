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
        // todo: singleton

        /// <summary>
        /// 服务控制timer，每30秒刷新一次
        /// </summary>
        private readonly Timer ServiceStatusCheckTimer = new Timer(30000);

        private ServiceManager()
        {
            ServiceStatusCheckTimer.Elapsed += ServiceStatusCheckTimer_Elapsed;
            ServiceStatusCheckTimer.Enabled = true;
        }

        private void ServiceStatusCheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            //if(now.Hour)
        }
    }
}
