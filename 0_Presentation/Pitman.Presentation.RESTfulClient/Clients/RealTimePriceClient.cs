using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RealTimePriceClient : RestfulClient, IRealTimePrice
    {
        public RealTimePriceClient(string serverAddress) : base(serverAddress, RealTimePriceConst.ServiceName) { }

        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockRealTimePriceDto>, IEnumerable<string>>(
                    RealTimePriceConst.Uri_GetLatest, 
                    stockCodes);
            }
        }
    }
}
