using Ore.Infrastructure.MarketData;
using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class StockBonusController : ApiController
    {
        public IEnumerable<StockBonusDto> Get(string stockCode)
        {
            /*test code for communication*************************************/
            var dto = new StockBonusDto()
            {
                Code = "600036",
                Market = Market.XSHG,
                ShortName = "招商银行",
            };
            var result = new List<StockBonusDto>();
            result.Add(dto);
            return result;
            /*test code for communication*************************************/
        }
    }
}
