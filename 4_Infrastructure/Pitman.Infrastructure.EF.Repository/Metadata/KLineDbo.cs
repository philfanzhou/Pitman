using Ore.Infrastructure.MarketData;
using System;

namespace Pitman.Infrastructure.EF.Repository
{
    public class KLineDbo : IStockKLine
    {
        public DateTime Time { get; set; }

        public double Amount { get; set; }

        public double Close { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public double Volume { get; set; }
    }
}
