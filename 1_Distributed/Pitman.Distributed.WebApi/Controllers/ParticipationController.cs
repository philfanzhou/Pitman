using Pitman.Distributed.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Time = new DateTime(1999, 9, 9, 9, 9, 9)
            };
            var result = new List<ParticipationDto>();
            result.Add(dto);
            return result;
            /*test code for communication*************************************/
#endif
            throw new System.NotImplementedException();

        }
    }
}
