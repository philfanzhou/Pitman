using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    public interface IStockBonusClient
    {
        IEnumerable<IStockBonus> Get(string stockCode);
    }
}
