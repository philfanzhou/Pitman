﻿using Framework.Infrastructure.Log;
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
        private const string _serviceName = "DataReview";
        /// <summary>
        /// 同花顺Api
        /// </summary>
        private ITongHuaShunReader tongHuaShunApi = ReaderFactory.Create();
        /// <summary>
        /// 存储数据服务
        /// </summary>
        private KLineAppService appService = new KLineAppService();

        public override string ServiceName
        {
            get { return _serviceName; }
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

            // 每天晚上8：00进行任务
            return DateTime.Now.Hour == 20;
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
                //股票的数据获取
                var kLineDay1 = GetDataFromApi(security.Code, KLineType.Min1);
                var kLineMin1 = GetDataFromApi(security.Code, KLineType.Min1);
                var kLineMin5 = GetDataFromApi(security.Code, KLineType.Min5);

                foreach(var it in kLineDay1)
                {
                    SaveDatas(KLineType.Day, security.Code, it);
                }

                foreach (var it in kLineMin1)
                {
                    SaveDatas(KLineType.Min1, security.Code, it);
                }

                foreach (var it in kLineMin5)
                {
                    SaveDatas(KLineType.Min5, security.Code, it);
                }

                // 更新进度
                base.Progress.Increase();
            }
        }

        private void SaveDatas(KLineType type, string stockCode, IStockKLine kLine)
        {
            try
            {
                // 检查是否已经存在记录
                if (appService.Exists(type, stockCode, kLine))
                {
                    // Todo:
                    // 如果已经存在就检查是否存在差异
                    // 如果存在差异就记录下数据用于审查
                }
                else
                {
                    // 不存在就添加
                    appService.Add(type, stockCode, kLine);
                }
            }
            catch(Exception ex)
            {
                LogHelper.Logger.WriteLine(string.Format("Save stock[{0}] data error.", stockCode));
                LogHelper.Logger.WriteLine(ex.ToString());
            }
        }

        private IEnumerable<IStockKLine> GetDataFromApi(string stockCode, KLineType type)
        {
            try
            {
                IEnumerable<IStockKLine> result = tongHuaShunApi.GetKLine(stockCode, type);
                return result == null ? new List<IStockKLine>() : result;
            }
            catch
            {
                // todo:因为同花顺数据可能不包含目前security的所有code，所以可能出现异常
                return new List<IStockKLine>();
            }
        }
    }
}