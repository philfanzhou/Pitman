using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IRealTimePrice
    {
        [OperationContract]
        IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes);

        [OperationContract]
        IEnumerable<StockRealTimePriceDto> GetData(
            IEnumerable<string> stockCodes,
            DateTime startDate,
            DateTime endDate);
    }
}
