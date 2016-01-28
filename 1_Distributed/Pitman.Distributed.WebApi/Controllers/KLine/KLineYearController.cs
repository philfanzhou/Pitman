using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.Distributed.DataTransferObject;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class KLineYearController : ApiController
    {
        public IEnumerable<StockKLineDto> Post([FromBody]KLineArgs args)
        {
#if DEBUG
            /*test code for communication * ************************************/
            var dto = new StockKLineDto()
            {
                Amount = 138887,
                High = 19.99,
                Open = 55.55
            };
            var result = new List<StockKLineDto>();
            result.Add(dto);
            return result;
            /*test code for communication************************************/
#else
            var appService = new KLineAppService();
            return appService.Get(KLineType.Year, args.StockCode, args.StartDate, args.EndDate).ToDto();
#endif
        }
    }
}