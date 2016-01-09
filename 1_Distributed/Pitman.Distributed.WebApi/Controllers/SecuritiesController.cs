using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
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
                Market = Market.XSHG,
                ShortName = "招商银行",
                Type = SecurityType.Sotck
            };
            var result = new List<SecurityDto>();
            result.Add(dto);
            return result;
            /*test code for communication************************************/
#endif
            throw new System.NotImplementedException();

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
