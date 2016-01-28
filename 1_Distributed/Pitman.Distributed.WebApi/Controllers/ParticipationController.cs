using Pitman.Application.MarketData;
using Pitman.Distributed.DataTransferObject;
using System.Collections.Generic;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class ParticipationController : ApiController
    {
        public IEnumerable<ParticipationDto> Get(string stockCode)
        {
#if DEBUG
            /*test code for communication*************************************/
            var dto = new ParticipationDto()
            {
                CostPrice1Day = 20,
                CostPrice20Day = 30,
                Time = new System.DateTime(1999, 9, 9, 9, 9, 9)
            };
            var result = new List<ParticipationDto>();
            result.Add(dto);
            return result;
            /*test code for communication*************************************/
#else
            var appService = new ParticipationAppService();
            return appService.Get(stockCode).ToDto();
#endif
        }
    }
}
