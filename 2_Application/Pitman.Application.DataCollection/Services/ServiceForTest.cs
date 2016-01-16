using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;

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
            // 获取所有证券信息
            var securities = GetDataFromApi().ToList();

            //设置进度对象
            base.Progress = new Progress(securities.Count);

            // 获取数据服务
            var appService = new SecurityAppService();

            // 检查并更新或增加
            foreach (var security in securities)
            {
                // 检查是否已经存在记录
                if (appService.Exists(security))
                {
                    // 如果已经存在就更新
                    appService.Update(security);
                }
                else
                {
                    // 不存在就添加
                    appService.Add(security);
                }

                // 更新进度
                base.Progress.Increase();
            }
        }

        protected override bool IsWorkingTime()
        {
            if(DateTime.Now - base.StopTime > new TimeSpan(0, 2, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static IEnumerable<ISecurity> GetDataFromApi()
        {
            SecurityInfoApi api = new SecurityInfoApi();
            return api.GetAllSecurity();
        }
    }
}
