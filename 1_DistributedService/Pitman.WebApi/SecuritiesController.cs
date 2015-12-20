using Ore.Infrastructure.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class SecuritiesController : ApiController
    {
        // http://localhost/selfhost/api/Securities
        // http://book.51cto.com/art/201408/448647.htm
        // http://www.cnblogs.com/artech/p/web-api-sample.html

        public IEnumerable<SecurityDto> Get()
        {
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
        }
    }
}
