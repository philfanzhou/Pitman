﻿using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.Distributed.DataTransferObject;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public class SecuritiesController : ApiController
    {
        public IEnumerable<SecurityDto> Get()
        {
//#if DEBUG
//            /*test code for communication * ************************************/
//            var dto = new SecurityDto()
//            {
//                Code = "600036",
//                Market = Market.XSHG,
//                ShortName = "招商银行",
//                Type = SecurityType.Sotck
//            };
//            var result = new List<SecurityDto>();
//            result.Add(dto);
//            return result;
//            /*test code for communication************************************/
//#endif

            var appservice = new SecurityAppService();
            return appservice.GetAll().Select(t => t.ToDto());
        }
    }
}
