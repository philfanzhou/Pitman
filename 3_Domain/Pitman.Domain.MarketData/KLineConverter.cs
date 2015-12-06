using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;

namespace Pitman.Domain.MarketData
{
    public static class KLineConverter
    {
        public static IEnumerable<IStockKLine> ConvertTo1Minute(IEnumerable<IStockRealTime> realTimeItems)
        {
            List<IStockKLine> result = new List<IStockKLine>();

            foreach (var realTimeItem in realTimeItems)
            {

            }

            return result;
        }
    }
}
