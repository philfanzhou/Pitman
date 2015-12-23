using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pitman.WebApi
{
    public class StockProfileController : ApiController
    {
        public IEnumerable<StockProfileDto> Get(string stockCode)
        {
            /*test code for communication*************************************/
            var dto = new StockProfileDto()
            {
                CodeA = "600036",
            };
            var result = new List<StockProfileDto>();
            result.Add(dto);
            return result;
            /*test code for communication*************************************/
        }
    }
}
