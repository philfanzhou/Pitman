using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pitman.Presentation.RESTfulClient
{
    internal class KLineClient : RestfulClient, IKLineService
    {
        public KLineClient(string serverAddress) : base(serverAddress, KLineServiceConst.ServiceName) { }

        public IEnumerable<StockKLineDto> GetBy1Minute(string stockCode, DateTime startTime, DateTime endTime)
        {
            PostData data = new PostData
            {
                StockCode = stockCode,
                StartDate = startTime,
                EndDate = endTime
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
            [DataMember(Name = "stockCodes")]
            public string StockCode { get; set; }

            [DataMember(Name = "startDate")]
            public DateTime StartDate { get; set; }

            [DataMember(Name = "endDate")]
            public DateTime EndDate { get; set; }
        }
    }
}
