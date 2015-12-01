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
            StockHistoryPrice data = new StockHistoryPrice()
            {
                Amount = 0.1,
                Code = "600036",
                Current = 50.01,
                High = 55.01,
                Low = 48.01,
                Market = Market.CCFX,
                Open = 49.01,
                PreClose = 49.01,
                ShortName = "测试测试",
                Time = DateTime.Now,
                Volume = 88.88
            };
            List<StockHistoryPrice> result = new List<StockHistoryPrice>();
            result.Add(data);
            return result;

            //RealTimeDataRepository repository = new RealTimeDataRepository();
            //var realTimeData = repository.GetData(stockCodes, startDate, endDate);
            //return PriceDataConvert.ConvertToOneMinuteData(realTimeData);
        }
    }
}
