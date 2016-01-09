using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
{
    public interface IStockStructureClient
    {
        IEnumerable<IStockStructure> Get(string stockCode);
    }
}
