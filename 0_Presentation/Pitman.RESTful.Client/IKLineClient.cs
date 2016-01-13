using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
{
    public interface IKLineClient : IClient
    {
        IEnumerable<IStockKLine> GetDay(string stockCode, DateTime startTime, DateTime endTime);
    }
}
