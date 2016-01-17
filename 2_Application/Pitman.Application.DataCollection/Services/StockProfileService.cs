using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Eastmoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal class StockProfileService
    {
        // 每天凌晨0：00进行一次数据获取

        internal static IStockProfile GetDataFromApi(string stockCode)
        {
            StockProfileApi api = new StockProfileApi();
            return api.GetStockProfile(stockCode);
        }
    }
}
