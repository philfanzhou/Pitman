using Ore.Infrastructure.MarketData;
using Pitman.Domain.MarketData;
using Pitman.Infrastructure.FileDatabase;
using System;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class HistoryPriceAppService
    {
        public IEnumerable<IStockHistoryPrice> GetMinutesData(string stockCodes, DateTime startDate, DateTime endDate)
        {
            RealTimeDataRepository repository = new RealTimeDataRepository();
            var realTimeData = repository.GetData(stockCodes, startDate, endDate);
            return PriceDataConvert.ConvertToOneMinuteData(realTimeData);
        }
    }
}
