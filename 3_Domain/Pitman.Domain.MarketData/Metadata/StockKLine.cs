using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Domain.MarketData
{
    internal class StockKLine : IStockKLine
    {
        public string Code { get; set; }

        public Market Market { get; set; }

        public string ShortName { get; set; }

        public double Open { get; set; }

        public double PreClose { get; set; }

        public double Current { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Volume { get; set; }

        public double Amount { get; set; }

        public DateTime Time { get; set; }
    }
}
