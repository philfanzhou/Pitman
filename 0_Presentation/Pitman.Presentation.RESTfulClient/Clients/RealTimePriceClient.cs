using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitman.DistributedService.Dto;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RealTimePriceClient : RestfulClient, IRealTimePrice
    {
        public RealTimePriceClient(string serverAddress) : base(serverAddress, "RealTimePrice") { }

        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            using (var client = GetHttpClient())
            {
                return client.PostAndReasAs<IEnumerable<StockRealTimePriceDto>, IEnumerable<string>>("Latest", stockCodes);
            }
        }
    }
}
