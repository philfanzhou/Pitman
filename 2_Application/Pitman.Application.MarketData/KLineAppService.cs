using Ore.Infrastructure.MarketData;
using Pitman.Domain.MarketData;
using Pitman.Infrastructure.FileDatabase;
using System;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class KLineAppService
    {
        public IEnumerable<IStockKLine> GetBy1Minute(string stockCodes, DateTime startDate, DateTime endDate)
        {
            /*******************test code***********************/
            StockKLine data = new StockKLine()
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
            List<StockKLine> result = new List<StockKLine>();
            result.Add(data);
            return result;
            /*******************test code***********************/

            //RealTimeDataRepository repository = new RealTimeDataRepository();
            //var realTimeData = repository.GetData(stockCodes, startDate, endDate);
            //return PriceDataConvert.ConvertToOneMinuteData(realTimeData);
        }
    }
}
