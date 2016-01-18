using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.Dto
{
    [DataContract(Name = "stockKLine")]
    public class StockKLineDto : IStockKLine
    {
        [DataMember(Name = "time")]
        private DateTimeDto time = new DateTimeDto();
        /// <summary>
        /// 日期与时间
        /// </summary>
        public DateTime Time
        {
            get { return time.Value; }
            set { time.Value = value; }
        }

        /// <summary>
        /// 今开
        /// </summary>
        [DataMember(Name = "open")]
        public double Open { get; set; }

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

        /// <summary>
        /// 收盘价
        /// </summary>
        [DataMember(Name = "close")]
        public double Close { get; set; }

        public override string ToString()
        {
            return this.time + string.Format("  Current:{0}", Close);
        }
    }
}
