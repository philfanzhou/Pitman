using Framework.Infrastructure.Log;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Application.DataCollection
{
    internal class StockStructureService : CollectionService
    {
        /// <summary>
        /// 数据获取服务
        /// </summary>
        private StockStructureApi _getDataApi = new StockStructureApi();
        /// <summary>
        /// 数据存储服务
        /// </summary>
        private StockStructureAppService _saveDataService = new StockStructureAppService();

        public override string ServiceName
        {
            get { return "StockStructure"; }
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
                var stockStructures = GetData(security.Code);
                if (stockStructures != null)
                {
                    foreach (var it in stockStructures)
                    {
                        SaveData(security.Code, it);
                    }
                }

                // 更新进度
                base.Progress.Increase();
            }
        }

        private IEnumerable<IStockStructure> GetData(string stockCode)
        {
            try
            {
                return _getDataApi.GetStockStructure(stockCode);
            }
            catch
            {
                // todo: 暂不处理获取数据的异常
                return null;
            }
        }

        private void SaveData(string stockCode, IStockStructure data)
        {
            try
            {
                // 检查是否已经存在记录
                if (_saveDataService.Exists(stockCode, data))
                {
                    // 如果已经存在就更新
                    _saveDataService.Update(stockCode, data);
                }
                else
                {
                    // 不存在就添加
                    _saveDataService.Add(stockCode, data);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("Save StockStructure[{0}] data error.", stockCode));
                LogHelper.Logger.WriteLine(ex.ToString());
            }
        }
    }
}
