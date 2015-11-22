using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class HistoryPriceService : IHistoryPrice
    {
        [WebInvoke(UriTemplate = HistoryPriceConst.Uri_GetData, 
            ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public IEnumerable<StockHistoryPriceDto> GetData(
            IEnumerable<string> stockCodes, 
            PriceDataType dataType, 
            DateTime startDate, 
            DateTime endDate)
        {
            StockHistoryPriceDto item = new StockHistoryPriceDto();
            return new List<StockHistoryPriceDto>() { item };
        }
    }
}
