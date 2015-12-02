using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.DistributedService.Contracts
{
    [DataContract(Name = "stockKLine")]
    public class StockKLineDto : IStockKLine
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// 股票简称
        /// </summary>
        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// 交易市场
        /// </summary>
        [DataMember(Name = "market")]
        public string MarketStr { get; set; }

        public Market Market
        {
            get
            {
                return (Market)Enum.Parse(typeof(Market), MarketStr);
            }
        }

        /// <summary>
        /// 今开
        /// </summary>
        [DataMember(Name = "open")]
        public double Open { get; set; }

        /// <summary>
        /// 昨收
        /// </summary>
        [DataMember(Name = "preClose")]
        public double PreClose { get; set; }

        /// <summary>
        /// 当前成交价
        /// </summary>
        [DataMember(Name = "current")]
        public double Current { get; set; }

        /// <summary>
        /// 最高
        /// </summary>
        [DataMember(Name = "high")]
        public double High { get; set; }

        /// <summary>
        /// 最低
        /// </summary>
        [DataMember(Name = "low")]
        public double Low { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        /// <summary>
        /// 成交额
        /// </summary>
        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        [DataMember(Name = "time")]
        private string time = "1970-01-01 00:00:00";
        /// <summary>
        /// 日期与时间
        /// </summary>
        public DateTime Time
        {
            get { return DateTime.Parse(time); }
            set { time = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }
    }
}
