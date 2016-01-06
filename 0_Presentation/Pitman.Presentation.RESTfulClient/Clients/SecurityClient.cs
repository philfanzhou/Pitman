using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class SecurityClient : RestfulClient, ISecurityClient
    {
        public SecurityClient(string serverAddress) : base(serverAddress, "api") { }

        public IEnumerable<ISecurity> GetAll()
        {
            using (var client = GetHttpClient())
            {
                return client.GetAndReadAs<IEnumerable<SecurityDto>>("Securities");
            }
        }
    }
}
