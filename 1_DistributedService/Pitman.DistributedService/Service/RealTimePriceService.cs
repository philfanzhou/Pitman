using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class RealTimePriceService : IRealTimePrice
    {
        [WebInvoke(UriTemplate = "Latest", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            StockRealTimePriceDto dto = new StockRealTimePriceDto();
            dto.ShortName = "测试股票";
            dto.Code = stockCodes.ToList()[0];
            dto.Time = DateTime.Now;
            dto.Current = 22.58;

            List<StockRealTimePriceDto> result = new List<StockRealTimePriceDto>();
            result.Add(dto);

            return result;
        }
    }
}
