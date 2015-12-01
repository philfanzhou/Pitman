using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IHistoryPrice
    {
        [OperationContract]
        IEnumerable<StockHistoryPriceDto> Get1MinuteData(string stockCode, DateTime startTime, DateTime endTime);
    }
}
