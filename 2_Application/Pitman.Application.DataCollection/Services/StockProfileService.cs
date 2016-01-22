using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitman.Application.MarketData;

namespace Pitman.Application.DataCollection
{
    internal class StockProfileService : CollectionService
    {
        private const string _serviceName = "StockProfile";

        public override string ServiceName
        {
            get { return _serviceName; }
        }

        // 每天凌晨0：00进行一次数据获取
        internal static IStockProfile GetDataFromApi(string stockCode)
        {
            StockProfileApi api = new StockProfileApi();
            return api.GetStockProfile(stockCode);
        }

        protected override void DoWork()
        {
            // 获取所有证券信息
            var securities = SecurityService.GetDataFromApi().ToList();
            //设置进度对象
            base.Progress = new Progress(securities.Count);
            // 获取数据服务
            var appService = new StockProfileAppService();

            // 检查并更新或增加
            foreach (var security in securities)
            {
                //股票的数据获取
                var stockProfile = GetDataFromApi(security.Code);

                // 检查是否已经存在记录
                if (appService.Exists(stockProfile))
                {
                    // 如果已经存在就更新
                    appService.Update(stockProfile);
                }
                else
                {
                    // 不存在就添加
                    appService.Add(stockProfile);
                }

                // 更新进度
                base.Progress.Increase();
            }
        }

        protected override bool IsWorkingTime()
        {
            // 每天只进行一次此任务
            if (IsCompletedToday())
            {
                return false;
            }

            //每天凌晨0：00进行一次数据获取
            return DateTime.Now.Hour == 0;
        }
    }
}
