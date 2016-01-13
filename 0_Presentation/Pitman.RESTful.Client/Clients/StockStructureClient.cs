using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
{
    internal class StockStructureClient : RestfulClient, IStockStructureClient
    {
        public StockStructureClient(string serverAddress) : base(serverAddress, "api") { }

        public IEnumerable<IStockStructure> Get(string stockCode)
        {
            using (var client = GetHttpClient())
            {
                string uri = string.Format("StockStructure/{0}", stockCode);
                return client.GetAndReadAs<IEnumerable<StockStructureDto>>(uri);
            }
        }
    }
}
