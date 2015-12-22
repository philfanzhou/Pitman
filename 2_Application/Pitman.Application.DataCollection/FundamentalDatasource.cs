using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    public class FundamentalDatasource
    {
        public static IStockProfile GetProfile(string stockCode)
        {
            StockProfileApi api = new StockProfileApi();
            return api.GetStockProfile(stockCode);
        }

        public static IEnumerable<IStockBonus> GetBonus(string stockCode)
        {
            StockBonusApi api = new StockBonusApi();
            return api.GetStockBonus(stockCode);
        }

        public static IEnumerable<IStockStructure> GetStructure(string stockCode)
        {
            StockStructureApi api = new StockStructureApi();
            return api.GetStockStructure(stockCode);
        }
    }
}
