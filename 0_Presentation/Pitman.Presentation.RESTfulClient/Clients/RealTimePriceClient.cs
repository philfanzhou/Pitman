using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RealTimePriceClient : RestfulClient, IRealTimePrice
    {
        public RealTimePriceClient(string serverAddress) : base(serverAddress, RealTimePriceConst.ServiceName) { }

        public IEnumerable<StockRealTimeDto> GetLatest(IEnumerable<string> stockCodes)
        {
            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockRealTimeDto>, IEnumerable<string>>(
                    RealTimePriceConst.Uri_GetLatest, 
                    stockCodes);
            }
        }

        public IEnumerable<StockRealTimeDto> GetData(
            string stockCodes, 
            DateTime startDate, 
            DateTime endDate)
        {
            PostData data = new PostData
            {
                StockCodes = stockCodes,
                StartDate = startDate,
                EndDate = endDate
            };

            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockRealTimeDto>, PostData>(
                    RealTimePriceConst.Uri_GetData,
                    data);
            }
        }

        [DataContract]
        private class PostData
        {
            [DataMember(Name = "stockCodes")]
            public string StockCodes { get; set; }

            [DataMember(Name = "startDate")]
            public DateTime StartDate { get; set; }

            [DataMember(Name = "endDate")]
            public DateTime EndDate { get; set; }
        }
    }
}
