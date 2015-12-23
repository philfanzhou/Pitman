using Ore.Infrastructure.MarketData;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
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
