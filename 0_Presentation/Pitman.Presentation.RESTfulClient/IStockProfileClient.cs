using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    public interface IStockProfileClient
    {
        IEnumerable<IStockProfile> Get(string stockCode);
    }
}
