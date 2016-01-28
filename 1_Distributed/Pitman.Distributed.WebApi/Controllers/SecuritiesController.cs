using Pitman.Application.MarketData;
using Pitman.Distributed.DataTransferObject;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class SecuritiesController : ApiController
    {
        public IEnumerable<SecurityDto> Get()
        {
#if DEBUG
            /*test code for communication * ************************************/
            var dto = new SecurityDto()
            {
                Code = "600036",
                Market = Ore.Infrastructure.MarketData.Market.XSHG,
                ShortName = "招商银行",
                Type = Ore.Infrastructure.MarketData.SecurityType.Sotck
            };
            var result = new List<SecurityDto>();
            result.Add(dto);
            return result;
            /*test code for communication************************************/
#else
            var appService = new SecurityAppService();
            return appService.GetAll().ToDto();
#endif
        }
    }
}
