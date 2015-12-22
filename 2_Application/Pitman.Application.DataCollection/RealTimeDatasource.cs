using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    public class RealTimeDatasource
    {
        public static IEnumerable<IStockRealTime> GetLatest(IEnumerable<string> stockCodes)
        {
            StockRealTimeApi api = new StockRealTimeApi();
            return api.GetData(stockCodes);
        }
    }
}
