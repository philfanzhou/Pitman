using Ore.Infrastructure.MarketData;
using Pitman.Distributed.DataTransferObject;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class StockProfileController : ApiController
    {
        public StockProfileDto Get(string stockCode)
        {
#if DEBUG
            /*test code for communication*************************************/
            var dto = new StockProfileDto()
            {
                CodeA = "600036",
            };
            return dto;
            /*test code for communication*************************************/
#endif
            throw new System.NotImplementedException();

            //return ConvertToDto(FundamentalDatasource.GetProfile(stockCode));
        }
    }
}
