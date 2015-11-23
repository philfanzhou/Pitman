using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pitman.Presentation.RESTfulClient
{
    internal class HistoryPriceClient : RestfulClient, IHistoryPrice
    {
        public HistoryPriceClient(string serverAddress) : base(serverAddress, HistoryPriceConst.ServiceName) { }

        public IEnumerable<StockHistoryPriceDto> GetData(
            IEnumerable<string> stockCodes, 
            PriceDataTypeDto dataType, 
            DateTime startDate, 
            DateTime endDate)
        {
            PostData data = new PostData
            {
                StockCodes = stockCodes,
                DataType = dataType,
                StartDate = startDate,
                EndDate = endDate
            };

            using (var client = GetHttpClient())
            {
                return client.PostAndReadAs<IEnumerable<StockHistoryPriceDto>, PostData>(
                    HistoryPriceConst.Uri_GetData,
                    data);
            }
        }

        [DataContract]
        private class PostData
        {
            [DataMember(Name = "stockCodes")]
            public IEnumerable<string> StockCodes { get; set; }

            [DataMember(Name = "dataType")]
            public PriceDataTypeDto DataType { get; set; }

            [DataMember(Name = "startDate")]
            public DateTime StartDate { get; set; }

            [DataMember(Name = "endDate")]
            public DateTime EndDate { get; set; }
        }
    }
}
