using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;

namespace Pitman.Domain.MarketData
{
    public static class KLineConverter
    {
        public static IEnumerable<IStockKLine> ConvertTo1Minute(IEnumerable<IStockRealTime> data)
        {
            throw new NotImplementedException();
        }
    }
}
