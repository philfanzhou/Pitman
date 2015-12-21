using Ore.Infrastructure.MarketData;
using Pitman.Application.MarketData;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class SecurityService : ISecurityService
    {
        [WebGet(UriTemplate = Contracts.SecurityServiceConst.Uri_GetAll,
            ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<SecurityDto> GetAll()
        {
            SecurityAppService appService = new SecurityAppService();

            /*test code for communication*************************************/
            var dto = new SecurityDto()
            {
                Code = "600036",
                Market = Market.XSHG,
                ShortName = "招商银行",
                Type = SecurityType.Sotck
            };

            var result = new List<SecurityDto>();
            result.Add(dto);
            return result.Select(t => ConvertToDto(t));
            /*test code for communication*************************************/

            //var result = appService.GetAll();
            //return result.Select(t => ConvertToDto(t));
        }

        private static SecurityDto ConvertToDto(ISecurity securityData)
        {
            return new SecurityDto
            {
                Code = securityData.Code,
                Market = securityData.Market,
                ShortName = securityData.ShortName,
                Type = securityData.Type
            };
        }
    }
}
