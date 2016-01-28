using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.SQLCE
{
    //
    // 摘要:
    //     K线数据定义
    public interface IStockKLine
    {
        //
        // 摘要:
        //     成交额
        double Amount { get; }
        //
        // 摘要:
        //     收盘
        double Close { get; }
        //
        // 摘要:
        //     最高
        double High { get; }
        //
        // 摘要:
        //     最低
        double Low { get; }
        //
        // 摘要:
        //     今开
        double Open { get; }
        //
        // 摘要:
        //     日期与时间
        DateTime Time { get; }
        //
        // 摘要:
        //     成交量
        double Volume { get; }
    }

    public class StockKLineDbo : IStockKLine
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
        /// 成交量
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public double Close { get; set; }
    }
}
