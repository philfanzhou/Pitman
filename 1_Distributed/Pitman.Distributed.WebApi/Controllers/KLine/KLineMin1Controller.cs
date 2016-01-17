using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class KLineMin1Controller : ApiController
    {
        public IEnumerable<IStockKLine> Post([FromBody]KLineArgs args)
        {
#if DEBUG
            /*test code for communication * ************************************/
            var dto = new StockKLineDto()
            {
                Amount = 138887,
                High = 19.99,
                Open = 32.09,
            };
            var result = new List<StockKLineDto>();
            result.Add(dto);
            return result;
            /*test code for communication************************************/
#endif

            throw new System.NotImplementedException();
        }
    }
}
