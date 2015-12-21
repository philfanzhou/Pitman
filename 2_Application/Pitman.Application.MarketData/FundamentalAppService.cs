using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.MarketData
{
    public class FundamentalAppService
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
