using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.RESTful.Client
{
    public interface IKLineClient
    {
        IEnumerable<IStockKLine> GetDay(string stockCode, DateTime startTime, DateTime endTime);
    }
}
