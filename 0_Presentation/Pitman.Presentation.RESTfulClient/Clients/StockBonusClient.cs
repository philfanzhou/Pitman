using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class StockBonusClient : RestfulClient, IStockBonusClient
    {
        public StockBonusClient(string serverAddress) : base(serverAddress, "api") { }

        public IEnumerable<IStockBonus> Get(string stockCode)
        {
            using (var client = GetHttpClient())
            {
                string uri = string.Format("StockBonus/{0}", stockCode);
                return client.GetAndReadAs<IEnumerable<StockBonusDto>>(uri);
            }
        }
    }
}
