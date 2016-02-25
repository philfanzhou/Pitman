using Framework.Infrastructure.Log;
using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.TongHuaShun;
using Pitman.Application.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pitman.Application.DataCollection
{
    /// <summary>
    /// 从多个数据源获取数据以审查本系统内数据正确性的服务
    /// </summary>
    internal class DataReviewService : CollectionService
    {
        #region Field
        /// <summary>
        /// 同花顺Api
        /// </summary>
        private ITongHuaShunReader _tongHuaShunApi = ReaderFactory.Create();
        /// <summary>
        /// 存储数据服务
        /// </summary>
        private KLineAppService _saveDataService = new KLineAppService();
        #endregion

        public override string ServiceName
        {
            get { return "DataReview"; }
        }

        protected override bool IsWorkingTime()
        {
            ///*************test code*****************/
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
            
            return DateTime.Now.Hour == 17;
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
                DeleteNotOpenedDay1(security.Code);
                
                // 处理同花顺日线数据
                var kLineDay1 = GetDataFromTongHuaShun(security.Code, KLineType.Day);
                SaveIfNotExist(KLineType.Day, security.Code, kLineDay1);
                // 处理同花顺Min1数据
                var kLineMin1 = GetDataFromTongHuaShun(security.Code, KLineType.Min1);
                SaveIfNotExist(KLineType.Min1, security.Code, kLineDay1);
                // 处理同花顺Min5数据
                var kLineMin5 = GetDataFromTongHuaShun(security.Code, KLineType.Min5);
                SaveIfNotExist(KLineType.Min5, security.Code, kLineDay1);

                // 更新进度
                base.Progress.Increase();
            }
        }

        /// <summary>
        /// 临时添加的数据处理，删除掉数据库内错误的日线数据。
        /// 删除已经停牌，但是记录了日线的数据。
        /// </summary>
        /// <param name="stockCode"></param>
        private void DeleteNotOpenedDay1(string stockCode)
        {
            try
            {
                var kLines = _saveDataService.Get(KLineType.Day, stockCode, new DateTime(2016, 1, 1), DateTime.Now)
                    .Where(p => p.Open - 0 < 0.000001);

                _saveDataService.Delete(KLineType.Day, stockCode, kLines);
            }
            catch(Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("DeleteNotOpenedDay1 [{0}] data error.", stockCode), this.ServiceName);
                LogHelper.Logger.WriteLine(ex.ToString(), this.ServiceName);
            }
        }

        private IEnumerable<IStockKLine> GetDataFromTongHuaShun(string stockCode, KLineType type)
        {
            try
            {
                IEnumerable<IStockKLine> result = _tongHuaShunApi.GetKLine(stockCode, type);
                return result == null ? new List<IStockKLine>() : result;
            }
            catch
            {
                // todo:因为同花顺数据可能不包含目前security的所有code，所以可能出现异常
                return new List<IStockKLine>();
            }
        }

        private void SaveIfNotExist(KLineType type, string stockCode, IEnumerable<IStockKLine> kLines)
        {
            try
            {
                _saveDataService.AddIfNotExist(type, stockCode, kLines);
            }
            catch (Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("Save stock[{0}] data error.", stockCode), this.ServiceName);
                LogHelper.Logger.WriteLine(ex.ToString(), this.ServiceName);
            }
        }
    }
}
