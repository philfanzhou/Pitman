using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using Pitman.Infrastructure.FileDatabase;
using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    public class RealTimeDatasource
    {
        public IEnumerable<IStockRealTime> GetLatest(IEnumerable<string> stockCodes)
        {
            //StockRealTimeApi api = new StockRealTimeApi();
            //return api.GetData()
            RealTimeDataRepository repository = new RealTimeDataRepository();
            return repository.GetLatest(stockCodes);
        }
    }
}
