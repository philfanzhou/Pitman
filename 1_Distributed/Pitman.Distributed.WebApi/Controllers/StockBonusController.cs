using Pitman.Application.MarketData;
using Pitman.Distributed.DataTransferObject;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class StockBonusController : ApiController
    {
        public IEnumerable<StockBonusDto> Get(string stockCode)
        {
#if DEBUG
            /*test code for communication*************************************/
            var dto = new StockBonusDto()
            {
                ShareSplitCount = 100,
            };
            var result = new List<StockBonusDto>();
            result.Add(dto);
            return result;
            /*test code for communication*************************************/
#else
            var appService = new StockBonusAppService();
            return appService.Get(stockCode).ToDto();
#endif
        }
    }
}
