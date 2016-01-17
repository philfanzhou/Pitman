﻿using Ore.Infrastructure.MarketData;
using Ore.Infrastructure.MarketData.DataSource.Sina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Application.DataCollection
{
    internal class StockBonusService
    {
        // 每天凌晨0：00进行一次数据获取

        internal static IEnumerable<IStockBonus> GetDataFromApi(string stockCode)
        {
            StockBonusApi api = new StockBonusApi();
            return api.GetStockBonus(stockCode);
        }
    }
}
