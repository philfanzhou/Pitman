﻿using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;

namespace Pitman.Domain.MarketData
{
    public static class PriceDataConvert
    {
        public static IEnumerable<StockHistoryPrice> ConvertToOneMinuteData(IEnumerable<IStockRealTimePrice> data)
        {
            throw new NotImplementedException();
        }
    }
}
