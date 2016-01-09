using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class KLineDayController : ApiController
    {
        public IEnumerable<IStockKLine> Post([FromBody]KLineArgs args)
        {

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
