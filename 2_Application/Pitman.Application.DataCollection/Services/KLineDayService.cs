using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Pitman.Application.MarketData;

namespace Pitman.Application.DataCollection
{
    internal class KLineDayService : CollectionService
    {
        private const string _serviceName = "KLineDay";

        public override string ServiceName
        {
            get { return _serviceName; }
        }

        /*
        1:调用Ore.sina里面的日线K线接口
        2：每天下午3：10开始进行所有股票的数据获取
        3：数据插入和更新，调用 Pitman.Application.MarketData.KLineAppService
        */
        internal static IEnumerable<IStockKLine> GetDataFromApi(IEnumerable<string> stockCodes)
        {
            StockKLineApi api = new StockKLineApi();
            return api.GetLatest(stockCodes);
        }

        internal static IStockKLine GetDataFromApi(string stockCode)
        {
            StockKLineApi api = new StockKLineApi();
            return api.GetLatest(stockCode);
        }

        protected override void DoWork()
        {
            // 获取所有证券信息
            var securities = SecurityService.GetDataFromApi().ToList();
            //设置进度对象
            base.Progress = new Progress(securities.Count);
            // 获取数据服务
            var appService = new KLineAppService();

            // 检查并更新或增加
            foreach (var security in securities)
            {
                //股票的数据获取
                var kLine = GetDataFromApi(security.Code);

                // 检查是否已经存在记录
                if (appService.Exists(KLineType.Day, security.Code, kLine))
                {
                    // 如果已经存在就更新
                    appService.Update(KLineType.Day, security.Code, kLine);
                }
                else
                {
                    // 不存在就添加
                    appService.Add(KLineType.Day, security.Code, kLine);
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

            // 每天下午3：10开始进行所有股票的数据获取
            return DateTime.Now.Hour == 15 && DateTime.Now.Minute == 10;
        }
    }
}
