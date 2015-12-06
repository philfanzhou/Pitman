﻿using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RealTimeClient : RestfulClient, IRealTimeService
    {
        public RealTimeClient(string serverAddress) : base(serverAddress, RealTimeServiceConst.ServiceName) { }

        public IEnumerable<StockRealTimeDto> GetLatest(IEnumerable<string> stockCodes)
        {
            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockRealTimeDto>, IEnumerable<string>>(
                    RealTimeServiceConst.Uri_GetLatest, 
                    stockCodes);
            }
        }
    }
}