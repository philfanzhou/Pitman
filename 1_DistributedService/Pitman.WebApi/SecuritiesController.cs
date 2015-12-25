using Ore.Infrastructure.MarketData;
using Pitman.Application.DataCollection;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class SecuritiesController : ApiController
    {
        // http://book.51cto.com/art/201408/448647.htm
        // http://www.cnblogs.com/artech/p/web-api-sample.html

        public IEnumerable<SecurityDto> Get()
        {
            /*test code for communication * ************************************/
            var dto = new SecurityDto()
            {
                Code = "600036",
                Market = Market.XSHG,
                ShortName = "招商银行",
                Type = SecurityType.Sotck
            };
            var result = new List<SecurityDto>();
            result.Add(dto);
            return result;
            /*test code for communication************************************/

            //return SecurityDatasource.GetAll().Select(t => ConvertToDto(t));
        }

        private static SecurityDto ConvertToDto(ISecurity data)
        {
            return new SecurityDto
            {
                Code = data.Code,
                ShortName = data.ShortName,
                Market = data.Market,
                Type = data.Type
            };
        }
    }
}
