using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Domain.MarketData
{
    public class StockIntraday : IStockIntraday
    {
        public string Code { get; set; }

        public Market Market { get; set; }

        public string ShortName { get; set; }

        public double Price { get; set; }

        public double AveragePrice { get; set; }

        public double Change { get; set; }

        public double ChangeRate { get; set; }

        public double Volume { get; set; }

        public double Amount { get; set; }

        public DateTime Time { get; set; }
    }
}
