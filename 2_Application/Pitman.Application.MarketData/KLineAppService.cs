﻿using Ore.Infrastructure.MarketData;
using Pitman.Domain.MarketData;
using Pitman.Infrastructure.FileDatabase;
using System;
using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public class KLineAppService
    {
        public IEnumerable<IStockKLine> GetBy1Minute(string stockCode, DateTime startDate, DateTime endDate)
        {
            RealTimeDataRepository repository = new RealTimeDataRepository();
            var realTimeData = repository.GetData(stockCode, startDate, endDate);
            return KLineConverter.ConvertTo1Minute(realTimeData);
        }
    }
}