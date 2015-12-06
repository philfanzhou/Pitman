using Ore.Infrastructure.MarketData;
using System;
using System.Runtime.Serialization;

namespace Pitman.DistributedService.Contracts
{
    [DataContract(Name = "stockKLine")]
    public class StockIntradayDto : IStockIntraday
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "market")]
        private string market = Market.Unknown.ToString();
        public Market Market
        {
            get
            {
                return (Market)Enum.Parse(typeof(Market), market);
            }
            set
            {
                market = value.ToString();
            }
        }

        [DataMember(Name = "time")]
        private string time = "1970-01-01 00:00:00";
        public DateTime Time
        {
            get { return DateTime.Parse(time); }
            set { time = value.ToString("yyyy-MM-dd hh:mm:ss"); }
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
    }
}
