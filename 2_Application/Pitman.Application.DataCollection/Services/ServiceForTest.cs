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
            int dataCount = 90;
            for(int i = 0; i < dataCount; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        protected override bool IsWorkingTime(DateTime now)
        {
            if(now - base.StopTime > new TimeSpan(0, 1, 0))
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
