using Ore.Infrastructure.MarketData;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    public interface IStockStructureClient
    {
        IEnumerable<IStockStructure> Get(string stockCode);
    }
}
