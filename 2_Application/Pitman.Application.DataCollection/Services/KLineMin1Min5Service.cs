using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.TongHuaShun;
using Pitman.Application.MarketData;

namespace Pitman.Application.DataCollection
{
    internal class KLineMin1Min5Service : CollectionService
    {
        /*
        1：每天由人工下载同花顺的分钟数据
        2：调用Ore.Tonghuashun的代码，读取同花顺Min1和Min5的K线数据
        3：存储数据到我们的系统中来
        4：每天晚上8：00进行任务
        */
        private const string _serviceName = "KLineMin1Min5";

        public override string ServiceName
        {
            get { return _serviceName; }
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
                var kLineMin1 = GetDataFromApi(security.Code, KLineType.Min1);
                var kLineMin5 = GetDataFromApi(security.Code, KLineType.Min5);

                foreach (var it in kLineMin1)
                {
                    SaveDatas(appService, KLineType.Min1, security.Code, it);
                }

                foreach (var it in kLineMin5)
                {
                    SaveDatas(appService, KLineType.Min5, security.Code, it);
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

            // 每天晚上8：00进行任务
            return DateTime.Now.Hour == 20;
        }

        private void SaveDatas(KLineAppService appService, KLineType type, string stockCode, IStockKLine kLine)
        {
            if(appService == null)
                throw new ArgumentOutOfRangeException("KLineAppService", "KLineAppService object is null");

            // 检查是否已经存在记录
            if (appService.Exists(type, stockCode, kLine))
            {
                // 如果已经存在就更新
                appService.Update(type, stockCode, kLine);
            }
            else
            {
                // 不存在就添加
                appService.Add(type, stockCode, kLine);
            }
        }

        internal static IEnumerable<IStockKLine> GetDataFromApi(string stockCode, KLineType type)
        {
            var api = ReaderFactory.Create();
            return api.GetKLine(stockCode, type);
        }
    }
}
