using Pitman.Distributed.Dto;
using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pitman.Presentation.RESTfulClient
{
    internal class IntradayClient : RestfulClient, IIntradayService
    {
        public IntradayClient(string serverAddress) : base(serverAddress, IntradayServiceConst.ServiceName) { }

        public IEnumerable<StockIntradayDto> GetData(string stockCode, DateTime startDate, DateTime endDate)
        {
            PostData data = new PostData
            {
                StockCode = stockCode,
                StartDate = startDate,
                EndDate = endDate
            };

            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockIntradayDto>, PostData>(
                    IntradayServiceConst.Uri_GetData,
                    data);
            }
        }

        [DataContract]
        private class PostData
        {
            [DataMember(Name = "stockCode")]
            public string StockCode { get; set; }

            [DataMember(Name = "startDate")]
            public DateTime StartDate { get; set; }

            [DataMember(Name = "endDate")]
            public DateTime EndDate { get; set; }
        }
    }
}
