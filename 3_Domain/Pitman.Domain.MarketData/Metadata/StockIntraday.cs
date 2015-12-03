using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Domain.MarketData
{
    internal class StockIntraday : IStockIntraday
    {
        public string Code { get; set; }

        public Market Market { get; set; }

        public string ShortName { get; set; }

        public double Current { get; set; }

        public double AveragePrice { get; set; }

        public double Change { get; set; }

        public double ChangeRate { get; set; }

        public double Volume
        {
            get { return IntradayVolume; }
            set { IntradayVolume = value; }
        }

        public double Amount
        {
            get { return IntradayAmount; }
            set { IntradayAmount = value; }
        }

        public DateTime Time { get; set; }

        public double IntradayVolume { get; set; }

        public double IntradayAmount { get; set; }

        public double TotalVolume { get; set; }

        public double TotalAmount { get; set; }
    }
}
