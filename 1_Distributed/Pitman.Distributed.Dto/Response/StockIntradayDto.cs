using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.Distributed.Dto
{
    [DataContract(Name = "stockIntraday")]
    public class StockIntradayDto : IStockIntraday
    {
        [DataMember(Name = "time")]
        private DateTimeDto time = new DateTimeDto();
        public DateTime Time
        {
            get { return time.Value; }
            set { time.Value = value; }
        }

        [DataMember(Name = "yesterdayClose")]
        public double YesterdayClose { get; set; }

        [DataMember(Name = "current")]
        public double Current { get; set; }

        [DataMember(Name = "averagePrice")]
        public double AveragePrice { get; set; }

        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        [DataMember(Name = "buyVolume")]
        public double BuyVolume { get; set; }

        [DataMember(Name = "sellVolume")]
        public double SellVolume { get; set; }

        public override string ToString()
        {
            return this.time + string.Format("  Current:{0}", Current);
        }
    }
}
