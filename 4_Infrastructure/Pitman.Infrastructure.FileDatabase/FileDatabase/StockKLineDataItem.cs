using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ore.Infrastructure.MarketData;

namespace Pitman.Infrastructure.FileDatabase
{
    internal struct StockKLineDataItem: IStockKLine
    {
        /// <summary>
        /// 日期与时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 今开
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// 最高
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// 最低
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// 收盘
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        public double Amount { get; set; }
    }
}
