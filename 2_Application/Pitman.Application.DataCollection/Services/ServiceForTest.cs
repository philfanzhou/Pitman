using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal class ServiceForTest : CollectionService
    {
        public override string ServiceName
        {
            get { return "ServiceForTest"; }
        }

        protected override void DoWork()
        {
            //设置进度对象
            base.Progress = new Progress(20);

            for(int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(500);

                // 更新进度
                base.Progress.Increase();
            }
        }

        protected override bool IsWorkingTime()
        {
            /************test code * ****************/
            if (DateTime.Now - base.StopTime > new TimeSpan(0, 0, 20))
            {
                return true;
            }
            else
            {
                return false;
            }
            /*****************************/
        }
    }
}
