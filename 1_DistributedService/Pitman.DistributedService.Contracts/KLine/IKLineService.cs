using Pitman.Distributed.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IKLineService
    {
        [OperationContract]
        IEnumerable<StockKLineDto> GetBy1Minute(string stockCode, DateTime startTime, DateTime endTime);
    }
}
