using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
{
    public interface IStockBonusClient
    {
        IEnumerable<IStockBonus> Get(string stockCode);
    }
}
