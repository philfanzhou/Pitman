using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pitman.Presentation.RESTfulClient
{
    internal class HistoryPriceClient : RestfulClient, IHistoryPrice
    {
        public HistoryPriceClient(string serverAddress) : base(serverAddress, HistoryPriceConst.ServiceName) { }

        public IEnumerable<StockHistoryPriceDto> Get1MinuteData(string stockCode, DateTime startTime, DateTime endTime)
        {
            Get1MinutePostData data = new Get1MinutePostData
            {
                StockCode = stockCode,
                StartDate = startTime,
                EndDate = endTime
            };

            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockHistoryPriceDto>, Get1MinutePostData>(
                    HistoryPriceConst.Uri_1MinuteData,
                    data);
            }
        }

        [DataContract]
        private class Get1MinutePostData
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
