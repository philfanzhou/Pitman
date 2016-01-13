using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;

namespace Pitman.RESTful.Client
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
