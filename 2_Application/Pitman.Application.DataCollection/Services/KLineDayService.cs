using Framework.Infrastructure.Log;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Application.DataCollection
{
    /// <summary>
    /// 每天定时获取日线数据的任务
    /// </summary>
    internal class KLineDayService : CollectionService
    {
        // 获取数据API
        private StockKLineApi _getDataApi = new StockKLineApi();
        // 存储数据服务
        private KLineAppService _saveDataService = new KLineAppService();

        public override string ServiceName
        {
            get { return "KLineDay"; }
        }

        protected override bool IsWorkingTime()
        {
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

            //// 每天只进行一次此任务
            //if (IsCompletedToday())
            //{
            //    return false;
            //}

            //// 每天下午3：10开始进行所有股票的数据获取
            //return DateTime.Now.Hour == 15 && DateTime.Now.Minute == 10;
        }

        protected override void DoWork()
        {
            // 获取所有证券信息
            var securities = GetAllSecurity();
            // 批量获取所有数据
            var datas = GetData(securities.Select(p => p.Code)).ToList();
            //设置进度对象
            base.Progress = new Progress(datas.Count);

            foreach (var data in datas)
            {
                //存储数据
                SaveData(data.Key, data.Value);
                // 更新进度
                base.Progress.Increase();
            }
        }

        private IEnumerable<KeyValuePair<string, IStockKLine>> GetData(IEnumerable<string> stockCodes)
        {
            IEnumerable<KeyValuePair<string, IStockKLine>> resule = null;
            int i = 0;
            do
            {
                try
                {
                    resule = _getDataApi.GetLatest(stockCodes);
                }
                finally
                {
                    i++;
                }

                // 尝试10次获取数据， 确保能够获取数据成功
                if (i > 9)
                {
                    break;
                }
            } while (resule == null);

            return resule;
        }

        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="data"></param>
        private void SaveData(string stockCode, IStockKLine data)
        {
            try
            {
                // 检查是否已经存在记录
                if (!_saveDataService.Exists(KLineType.Day, stockCode, data))
                {
                    // 不存在就添加
                    _saveDataService.Add(KLineType.Day, stockCode, data);
                }
            }
            catch(Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("Save stock[{0}] data error.", stockCode), this.ServiceName);
                LogHelper.Logger.WriteLine(ex.ToString(), this.ServiceName);
            }
        }
    }
}
