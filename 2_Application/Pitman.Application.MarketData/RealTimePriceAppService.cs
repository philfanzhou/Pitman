using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;
using System;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class RealTimePriceAppService
    {
        public IEnumerable<IStockRealTimePrice> GetLatest(IEnumerable<string> stockCodes)
        {
            RealTimeDataRepository repository = new RealTimeDataRepository();
            return repository.GetLatest(stockCodes);
        }

        public IEnumerable<IStockRealTimePrice> GetData(
            IEnumerable<string> stockCodes,
            DateTime startDate,
            DateTime endDate)
        {
            RealTimeDataRepository repository = new RealTimeDataRepository();
            return repository.GetData(stockCodes, startDate, endDate);
        }
    }
}
