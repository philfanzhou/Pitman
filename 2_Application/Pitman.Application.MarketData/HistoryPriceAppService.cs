using Ore.Infrastructure.MarketData;
using Pitman.Domain.MarketData;
using System;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class HistoryPriceAppService
    {
        public IEnumerable<IStockHistoryPrice> GetMinutesData(
            IEnumerable<string> stockCodes,
            DateTime startDate,
            DateTime endDate)
        {
            StockHistoryPrice item = new StockHistoryPrice();
            return new List<StockHistoryPrice>() { item };
        }
    }
}
