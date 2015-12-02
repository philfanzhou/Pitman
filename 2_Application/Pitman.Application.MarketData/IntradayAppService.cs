using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.MarketData
{
    public class IntradayAppService
    {
        public IEnumerable<IStockIntraday> GetData(string stockCode, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
