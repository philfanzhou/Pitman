using Pitman.Distributed.Dto;
using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pitman.Presentation.RESTfulClient
{
    internal class KLineClient : RestfulClient, IKLineService
    {
        public KLineClient(string serverAddress) : base(serverAddress, KLineServiceConst.ServiceName) { }

        public IEnumerable<StockKLineDto> GetBy1Minute(string stockCode, DateTime startDate, DateTime endDate)
        {
            PostData data = new PostData
            {
                StockCode = stockCode,
                StartDate = startDate,
                EndDate = endDate
            };

            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockKLineDto>, PostData>(
                    KLineServiceConst.Uri_GetBy1Minute,
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
