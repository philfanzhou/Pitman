using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class KLineClient : RestfulClient, IKLineClient
    {
        public KLineClient(string serverAddress) : base(serverAddress, "api") { }
        
        public IEnumerable<IStockKLine> GetDay(string stockCode, DateTime startTime, DateTime endTime)
        {
            KLineArgs data = new KLineArgs
            {
                StockCode = stockCode,
                StartDate = startTime,
                EndDate = endTime
            };

            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockKLineDto>, KLineArgs>("KLineDay", data);
            }
        }
    }
}
