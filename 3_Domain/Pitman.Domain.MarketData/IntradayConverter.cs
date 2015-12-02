using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Domain.MarketData
{
    public class IntradayConverter
    {
        public static IEnumerable<IStockIntraday> ConvertTo1Minute(IEnumerable<IStockRealTime> data)
        {
            throw new NotImplementedException();
        }
    }
}
