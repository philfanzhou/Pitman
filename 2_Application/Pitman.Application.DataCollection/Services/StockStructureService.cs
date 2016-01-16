using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal class StockStructureService
    {
        internal static IEnumerable<IStockStructure> GetDataFromApi(string stockCode)
        {
            StockStructureApi api = new StockStructureApi();
            return api.GetStockStructure(stockCode);
        }
    }
}
