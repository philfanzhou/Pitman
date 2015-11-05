using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.MarketData
{
    public class RealTimePriceAppService
    {
        public IEnumerable<IStockRealTimePrice> GetLatest(IEnumerable<string> stockCodes)
        {
            throw new NotImplementedException();
        }
    }
}
