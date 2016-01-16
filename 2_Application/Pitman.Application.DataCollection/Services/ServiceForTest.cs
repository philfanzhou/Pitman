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
            get
            {
                return "ServiceForTest";
            }
        }

        protected override void DoWork()
        {
            int dataCount = 30;

            //设置进度对象
            base.Progress = new Progress(dataCount);

            for(int i = 0; i < dataCount; i++)
            {
                // 模拟进行工作
                System.Threading.Thread.Sleep(1000);

                // 更新进度
                base.Progress.Increase();
            }
        }

        protected override bool IsWorkingTime()
        {
            if(DateTime.Now - base.StopTime > new TimeSpan(0, 1, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
