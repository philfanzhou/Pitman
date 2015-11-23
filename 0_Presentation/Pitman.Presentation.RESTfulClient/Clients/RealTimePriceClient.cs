using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pitman.Presentation.RESTfulClient
{
    internal class RealTimePriceClient : RestfulClient, IRealTimePrice
    {
        public RealTimePriceClient(string serverAddress) : base(serverAddress, RealTimePriceConst.ServiceName) { }

        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockRealTimePriceDto>, IEnumerable<string>>(
                    RealTimePriceConst.Uri_GetLatest, 
                    stockCodes);
            }
        }

        public IEnumerable<StockRealTimePriceDto> GetData(
            IEnumerable<string> stockCodes, 
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
                return client.PostAndReadAs<IEnumerable<StockRealTimePriceDto>, PostData>(
                    RealTimePriceConst.Uri_GetData,
                    data);
            }
        }

        [DataContract]
        private class PostData
        {
            [DataMember(Name = "stockCodes")]
            public IEnumerable<string> StockCodes { get; set; }

            [DataMember(Name = "startDate")]
            public DateTime StartDate { get; set; }

            [DataMember(Name = "endDate")]
            public DateTime EndDate { get; set; }
        }
    }
}
