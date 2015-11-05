using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class RealTimePriceService : IRealTimePrice
    {
        [WebInvoke(UriTemplate = "/Latest",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json)]
        public IEnumerable<StockRealTimePriceDto> GetLatest(IEnumerable<string> stockCodes)
        {
            StockRealTimePriceDto dto = new StockRealTimePriceDto();
            dto.ShortName = "测试股票";

            return new List<StockRealTimePriceDto>() { dto };
        }
    }
}
