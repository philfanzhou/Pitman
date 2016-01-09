using Ore.Infrastructure.MarketData;
using Pitman.Distributed.Dto;
using System.Collections.Generic;

namespace Pitman.RESTful.Client
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
