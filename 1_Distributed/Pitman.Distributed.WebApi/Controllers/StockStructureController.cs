using Ore.Infrastructure.MarketData;
using Pitman.Distributed.DataTransferObject;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class StockStructureController : ApiController
    {
        public IEnumerable<StockStructureDto> Get(string stockCode)
        {
#if DEBUG
            /*test code for communication*************************************/
            var dto = new StockStructureDto()
            {
                SharesA = 12324232,
                Reason = "测试测试测试"
            };
            var result = new List<StockStructureDto>();
            result.Add(dto);
            return result;
            /*test code for communication*************************************/
#endif
            throw new System.NotImplementedException();

            //return FundamentalDatasource.GetStructure(stockCode).Select(t => ConvertToDto(t));
        }
    }
}
