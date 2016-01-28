using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Pitman.Distributed.DataTransferObject
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

    public static class KLineConverter
    {
        public static IEnumerable<StockKLineDto> ToDto(this IEnumerable<IStockKLine> self)
        {
            return self.Select(p => p.ToDto());
        }

        public static StockKLineDto ToDto(this IStockKLine self)
        {
            StockKLineDto outputData = new StockKLineDto
            {
                //
                // 摘要:
                //     成交额
                Amount = self.Amount,
                //
                // 摘要:
                //     收盘
                Close = self.Close,
                //
                // 摘要:
                //     最高
                High = self.High,
                //
                // 摘要:
                //     最低
                Low = self.Low,
                //
                // 摘要:
                //     今开
                Open = self.Open,
                //
                // 摘要:
                //     日期与时间
                Time = self.Time,
                //
                // 摘要:
                //     成交量
                Volume = self.Volume
            };

            return outputData;
        }
    }
}
