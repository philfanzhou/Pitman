using System;
using System.Runtime.Serialization;

namespace Pitman.DistributedService.Dto
{
    [DataContract]
    public class StockRealTimePriceDto
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// 股票简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 交易市场
        /// </summary>
        public MarketDto Market { get; set; }

        /// <summary>
        /// 今开
        /// </summary>
        public double TodayOpen { get; set; }

        /// <summary>
        /// 昨收
        /// </summary>
        public double YesterdayClose { get; set; }

        /// <summary>
        /// 当前成交价
        /// </summary>
        public double Current { get; set; }

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
        /// 日期与时间
        /// </summary>
        public DateTime Time { get; set; }

        #region 卖盘

        /// <summary>
        /// 卖五价
        /// </summary>
        public double Sell5Price { get; set; }

        /// <summary>
        /// 卖五量
        /// </summary>
        public double Sell5Volume { get; set; }

        /// <summary>
        /// 卖四价
        /// </summary>
        public double Sell4Price { get; set; }

        /// <summary>
        /// 卖四量
        /// </summary>
        public double Sell4Volume { get; set; }

        /// <summary>
        /// 卖三价
        /// </summary>
        public double Sell3Price { get; set; }

        /// <summary>
        /// 卖三量
        /// </summary>
        public double Sell3Volume { get; set; }

        /// <summary>
        /// 卖二价
        /// </summary>
        public double Sell2Price { get; set; }

        /// <summary>
        /// 卖二量
        /// </summary>
        public double Sell2Volume { get; set; }

        /// <summary>
        /// 卖一价
        /// </summary>
        public double Sell1Price { get; set; }

        /// <summary>
        /// 卖一量
        /// </summary>
        public double Sell1Volume { get; set; }

        #endregion

        #region 买盘

        /// <summary>
        /// 买一价
        /// </summary>
        public double Buy1Price { get; set; }

        /// <summary>
        /// 买一量
        /// </summary>
        public double Buy1Volume { get; set; }

        /// <summary>
        /// 买二价
        /// </summary>
        public double Buy2Price { get; set; }

        /// <summary>
        /// 买二量
        /// </summary>
        public double Buy2Volume { get; set; }

        /// <summary>
        /// 买三价
        /// </summary>
        public double Buy3Price { get; set; }

        /// <summary>
        /// 买三量
        /// </summary>
        public double Buy3Volume { get; set; }

        /// <summary>
        /// 买四价
        /// </summary>
        public double Buy4Price { get; set; }

        /// <summary>
        /// 买四量
        /// </summary>
        public double Buy4Volume { get; set; }

        /// <summary>
        /// 买五价
        /// </summary>
        public double Buy5Price { get; set; }

        /// <summary>
        /// 买五量
        /// </summary>
        public double Buy5Volume { get; set; }

        #endregion
    }
}
