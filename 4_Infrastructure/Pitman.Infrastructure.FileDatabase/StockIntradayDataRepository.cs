using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    public class StockIntradayDataRepository
    {
    }

    internal static class StockIntradayExt
    {
        public static StockIntradayDataItem Convert(this IStockIntraday self)
        {
            StockIntradayDataItem outputData = new StockIntradayDataItem
            {
                ///// <summary>
                ///// 代码
                ///// </summary>
                //Code = self.Code,

                ///// <summary>
                ///// 交易市场
                ///// </summary>
                //Market = self.Market,

                ///// <summary>
                ///// 简称
                ///// </summary>
                //ShortName = self.ShortName,

                /// <summary>
                /// 时间
                /// </summary>
                Time = self.Time,

                /// <summary>
                /// 当前价
                /// </summary>
                Current = self.Current,

                /// <summary>
                /// 均价 = 当前时刻总成交额 / 当前时刻总成交量
                /// </summary>
                AveragePrice = self.AveragePrice,

                /// <summary>
                /// 前一交易日收盘价
                /// </summary>
                YesterdayClose = self.YesterdayClose,

                ///// <summary>
                ///// 涨跌
                ///// </summary>
                // Change = self.Change,

                ///// <summary>
                ///// 涨跌幅
                ///// </summary>
                // ChangeRate = self.ChangeRate,

                /// <summary>
                /// 分时成交量
                /// </summary>
                Volume = self.Volume,

                /// <summary>
                /// 分时成交额
                /// </summary>
                Amount = self.Amount,

                /// <summary>
                /// 委买
                /// </summary>
                BuyVolume = self.BuyVolume,

                /// <summary>
                /// 委卖
                /// </summary>
                SellVolume = self.SellVolume
            };

            return outputData;
        }
    }
}
