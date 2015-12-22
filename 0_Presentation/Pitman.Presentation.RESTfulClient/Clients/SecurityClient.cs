using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class SecurityClient : RestfulClient
    {
        public SecurityClient(string serverAddress) : base(serverAddress, SecurityServiceConst.ServiceName) { }

        public IEnumerable<SecurityDto> GetAll()
        {
            using (var client = GetHttpClient())
            {
                return client.GetAndReadAs<IEnumerable<SecurityDto>>(SecurityServiceConst.Uri_GetAll);
            }
        }
    }
}
