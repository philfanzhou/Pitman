using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Pitman.Application.MarketData;
using System;
using System.Linq;
using Framework.Infrastructure.Log;

namespace Pitman.Application.DataCollection
{
    internal class StockProfileService : CollectionService
    {
        /// <summary>
        /// 数据获取服务
        /// </summary>
        private StockProfileApi _getDataApi = new StockProfileApi();
        /// <summary>
        /// 数据存储服务
        /// </summary>
        private StockProfileAppService _saveDataService = new StockProfileAppService();

        public override string ServiceName
        {
            get { return "StockProfile"; }
        }

        protected override bool IsWorkingTime()
        {
            ///*************test code*****************/
            //if (IsCompletedToday())
            //{
            //    return false;
            //}
            //if (DateTime.Now - base.StopTime > new TimeSpan(0, 2, 0))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            ///******************************/

            // 每天只进行一次此任务
            if (IsCompletedToday())
            {
                return false;
            }

            //每天凌晨0：00进行一次数据获取
            return DateTime.Now.Hour == 0;
        }

        protected override void DoWork()
        {
            // 获取所有证券信息
            var securities = GetAllSecurity().ToList();
            //设置进度对象
            base.Progress = new Progress(securities.Count);

            // 检查并更新或增加
            foreach (var security in securities)
            {
                //股票的数据获取
                var stockProfile = GetData(security.Code);

                if (stockProfile != null)
                {
                    SaveData(stockProfile);
                }

                // 降低获取数据的频率，避免被服务端封ip
                System.Threading.Thread.Sleep(500);

                // 更新进度
                base.Progress.Increase();
            }
        }

        private IStockProfile GetData(string stockCode)
        {
            try
            {
                return _getDataApi.GetStockProfile(stockCode);
            }
            catch
            {
                // todo: 暂不处理获取数据的异常
                return null;
            }
        }

        private void SaveData(IStockProfile data)
        {
            try
            {
                // 检查是否已经存在记录
                if (_saveDataService.Exists(data))
                {
                    // 如果已经存在就更新
                    _saveDataService.Update(data);
                }
                else
                {
                    // 不存在就添加
                    _saveDataService.Add(data);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine(ex.ToString(), this.ServiceName);
            }
        }
    }
}
