using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;
using Quantum.Domain.MarketData;
using System;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class IntradayAppService
    {
        public IEnumerable<IStockIntraday> GetData(string stockCode, DateTime startDate, DateTime endDate)
        {
            RealTimeDataRepository repository = new RealTimeDataRepository();
            var realTimeData = repository.GetData(stockCode, startDate, endDate);
            return IntradayConverter.ConvertToIntraday(realTimeData);
        }
    }
}
