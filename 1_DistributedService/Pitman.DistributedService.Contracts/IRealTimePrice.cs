using Pitman.DistributedService.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IRealTimePrice
    {
        IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes);
    }
}
