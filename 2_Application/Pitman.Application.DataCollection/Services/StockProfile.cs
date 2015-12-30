using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal class StockProfile
    {
        internal static IStockProfile GetDataFromApi(string stockCode)
        {
            StockProfileApi api = new StockProfileApi();
            return api.GetStockProfile(stockCode);
        }
    }
}
