using Ore.Infrastructure.MarketData;
using Pitman.Infrastructure.FileDatabase;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class RealTimeAppService
    {
        public IEnumerable<IStockRealTime> GetLatest(IEnumerable<string> stockCodes)
        {
            RealTimeDataRepository repository = new RealTimeDataRepository();
            return repository.GetLatest(stockCodes);
        }
    }
}
