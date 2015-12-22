using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System.Collections.Generic;

namespace Pitman.Application.DataCollection
{
    public class FundamentalDatasource
    {
        public IStockProfile GetProfile(string stockCode)
        {
            StockProfileApi api = new StockProfileApi();
            return api.GetStockProfile(stockCode);
        }

        public IEnumerable<IStockBonus> GetBonus(string stockCode)
        {
            StockBonusApi api = new StockBonusApi();
            return api.GetStockBonus(stockCode);
        }

        public IEnumerable<IStockStructure> GetStructure(string stockCode)
        {
            StockStructureAPI api = new StockStructureAPI();
            return api.GetStockStructure(stockCode);
        }
    }
}
