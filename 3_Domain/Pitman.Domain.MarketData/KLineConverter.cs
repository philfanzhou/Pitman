using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.Domain.MarketData
{
    public static class KLineConverter
    {
        public static IEnumerable<IStockKLine> ConvertTo1Minute(IEnumerable<IStockRealTime> realTimeItems)
        {
            KLine1MinuteInfo info = new KLine1MinuteInfo();
            info.Add(realTimeItems);
            return info.Items;
        }
    }
}
