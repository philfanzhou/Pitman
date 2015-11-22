using System;
using System.Runtime.Serialization;

namespace Pitman.DistributedService.Dto
{
    [DataContract(Name = "stockHistoryPrice")]
    public class StockHistoryPriceDto
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
        public MarketDto Market { get; set; }

        /// <summary>
        /// 今开
        /// </summary>
        [DataMember(Name = "todayOpen")]
        public double TodayOpen { get; set; }

        /// <summary>
        /// 昨收
        /// </summary>
        [DataMember(Name = "yesterdayClose")]
        public double YesterdayClose { get; set; }

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
