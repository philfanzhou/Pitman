using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class KLineDayController : ApiController
    {
        public IEnumerable<IStockKLine> Post([FromBody]KLineArgs args)
        {
#if DEBUG
            /*test code for communication * ************************************/
            var dto = new StockKLineDto()
            {
                Amount = 138887,
                High = 19.99,
                Open = 10.01
            };
            var result = new List<StockKLineDto>();
            result.Add(dto);
            return result;
            /*test code for communication************************************/
#endif
            throw new System.NotImplementedException();
        }

        private static StockKLineDto ConvertToDto(IStockKLine data)
        {
            return new StockKLineDto
            {
                Amount = data.Amount,
                Close = data.Close,
                High = data.High,
                Low = data.Low,
                Open = data.Open,
                Time = data.Time,
                Volume = data.Volume
            };
        }
    }
}
