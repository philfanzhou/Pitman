using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IRealTimePrice
    {
        [OperationContract]
        IEnumerable<StockRealTimeDto> GetLatest(IEnumerable<string> stockCodes);

        [OperationContract]
        IEnumerable<StockRealTimeDto> GetData(
            string stockCodes,
            DateTime startDate,
            DateTime endDate);
    }
}
