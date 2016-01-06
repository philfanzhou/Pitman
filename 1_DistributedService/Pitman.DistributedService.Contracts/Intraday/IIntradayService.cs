using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IIntradayService
    {
        [OperationContract]
        IEnumerable<StockIntradayDto> GetData(string stockCode, DateTime startDate, DateTime endDate);
    }
}
