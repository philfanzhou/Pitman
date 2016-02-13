using Framework.Infrastructure.Log;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Pitman.Application.MarketData;
using System;
using System.Linq;

namespace Pitman.Application.DataCollection
{
    internal class KLineDayService : CollectionService
    {
        private const string _serviceName = "KLineDay";
        // 获取数据API
        private StockKLineApi  sinaApi = new StockKLineApi();
        // 存储数据服务
        private KLineAppService appService = new KLineAppService();

        public override string ServiceName
        {
            get { return _serviceName; }
        }

        protected override bool IsWorkingTime()
        {
#if DEBUG
            /*************test code*****************/
            if (DateTime.Now - base.StopTime > new TimeSpan(0, 2, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
            /******************************/
#endif

            // 每天只进行一次此任务
            if (IsCompletedToday())
            {
                return false;
            }

            // 每天下午3：10开始进行所有股票的数据获取
            return DateTime.Now.Hour == 15 && DateTime.Now.Minute == 10;
        }

        protected override void DoWork()
        {
            // 获取所有证券信息
            var securities = SecurityService.GetDataFromApi().ToList();
            //设置进度对象
            base.Progress = new Progress(securities.Count);

            // 检查并更新或增加
            foreach (var security in securities)
            {
                //获取数据
                var kLine = GetKLine(security.Code);

                if (kLine != null)
                {
                    //存储数据
                    SaveKLineData(security.Code, kLine);
                }

                // 降低获取数据的频率，避免被服务端封ip
                System.Threading.Thread.Sleep(500);

                // 更新进度
                base.Progress.Increase();
            }
        }

        /// <summary>
        /// 获取日线数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        private IStockKLine GetKLine(string stockCode)
        {
            IStockKLine result = null;

            try
            {
                result = sinaApi.GetLatest(stockCode);
            }
            catch(Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("Get stock[{0}] data error.", stockCode));
                LogHelper.Logger.WriteLine(ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="kLine"></param>
        private void SaveKLineData(string stockCode, IStockKLine kLine)
        {
            try
            {
                // 检查是否已经存在记录
                if (!appService.Exists(KLineType.Day, stockCode, kLine))
                {
                    // 不存在就添加
                    appService.Add(KLineType.Day, stockCode, kLine);
                }
            }
            catch(Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("Save stock[{0}] data error.", stockCode));
                LogHelper.Logger.WriteLine(ex.ToString());
            }
        }
    }
}
