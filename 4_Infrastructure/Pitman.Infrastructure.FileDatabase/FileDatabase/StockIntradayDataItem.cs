using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Infrastructure.MemoryMap;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct StockIntradayDataItem: IStockIntraday
    {
        /// <summary>
        /// 代码
        /// </summary>
        private String64 code;
        public string Code
        {
            get
            {
                return code.Value;
            }
            set
            {
                code.Value = value;
            }
        }

        /// <summary>
        /// 交易市场
        /// </summary>
        public Market Market { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        private String256 shortName;
        public string ShortName
        {
            get
            {
                return shortName.Value;
            }
            set
            {
                shortName.Value = value;
            }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 当前价
        /// </summary>
        public double Current { get; set; }

        /// <summary>
        /// 均价 = 当前时刻总成交额 / 当前时刻总成交量
        /// </summary>
        public double AveragePrice { get; set; }

        /// <summary>
        /// 前一交易日收盘价
        /// </summary>
        public double YesterdayClose { get; set; }

        ///// <summary>
        ///// 涨跌
        ///// </summary>
        //public double Change { get; set; }

        ///// <summary>
        ///// 涨跌幅
        ///// </summary>
        //public double ChangeRate { get; set; }

        /// <summary>
        /// 分时成交量
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// 分时成交额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 委买
        /// </summary>
        public double BuyVolume { get; set; }

        /// <summary>
        /// 委卖
        /// </summary>
        public double SellVolume { get; set; }
    }
}
