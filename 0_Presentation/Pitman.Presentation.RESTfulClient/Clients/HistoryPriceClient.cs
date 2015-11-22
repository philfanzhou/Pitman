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
            PriceDataType dataType, 
            DateTime startDate, 
            DateTime endDate)
        {
            //JsonSerializer serializer = new JsonSerializer();
            //string dataString = string.Format("\"{0}\":{1},\"{2}\":{3},\"{4}\":{5},\"{6}\":{7}",
            //    "stockCodes", serializer.Serialize(stockCodes),
            //    "dataType", serializer.Serialize(dataType),
            //    "startDate", serializer.Serialize(startDate),
            //    "endDate", serializer.Serialize(endDate));
            //string postString = "{" + dataString + "}";

            //using (var client = GetHttpClient())
            //{
            //    return client.PostAndReadAs<IEnumerable<StockHistoryPriceDto>>(
            //        HistoryPriceConst.Uri_GetData,
            //        postString);
            //}

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
            public PriceDataType DataType { get; set; }

            [DataMember(Name = "startDate")]
            public DateTime StartDate { get; set; }

            [DataMember(Name = "endDate")]
            public DateTime EndDate { get; set; }
        }
    }
}
