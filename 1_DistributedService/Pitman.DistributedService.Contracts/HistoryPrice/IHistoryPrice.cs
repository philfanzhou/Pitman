﻿using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IHistoryPrice
    {
        [OperationContract]
        IEnumerable<StockHistoryPriceDto> GetData(
            IEnumerable<string> stockCodes, 
            PriceDataType dataType,
            DateTime startDate, 
            DateTime endDate);
    }
}