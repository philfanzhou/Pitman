using Ore.Infrastructure.MarketData;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class StockProfileClient : RestfulClient, IStockProfileClient
    {
        public StockProfileClient(string serverAddress) : base(serverAddress, "api") { }

        public IStockProfile Get(string stockCode)
        {
            using (var client = GetHttpClient())
            {
                string uri = string.Format("StockProfile/{0}", stockCode);
                return client.GetAndReadAs<StockProfileDto>(uri);
            }
        }
    }
}
