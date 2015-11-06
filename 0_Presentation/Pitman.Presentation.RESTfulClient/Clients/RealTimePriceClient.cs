using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RealTimePriceClient : RestfulClient, IRealTimePrice
    {
        public RealTimePriceClient(string serverAddress) : base(serverAddress, RealTimePrice.ServiceName) { }

        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            using (var client = GetHttpClient())
            {
                return client.PostAndReasAs<IEnumerable<StockRealTimePriceDto>, IEnumerable<string>>(RealTimePrice.Uri_GetLatest, stockCodes);
            }
        }
    }
}
