using Pitman.Distributed.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IRealTimeService
    {
        [OperationContract]
        IEnumerable<StockRealTimeDto> GetLatest(IEnumerable<string> stockCodes);
    }
}
