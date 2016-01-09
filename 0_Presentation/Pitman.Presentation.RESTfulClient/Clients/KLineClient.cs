using Pitman.Distributed.Dto;
using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ore.Infrastructure.MarketData;

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
