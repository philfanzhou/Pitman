using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class CollectionStatusClient : RestfulClient, ICollectionStatusService
    {
        public CollectionStatusClient(string serverAddress) : base(serverAddress, CollectionStatusServiceConst.ServiceName) { }

        public IEnumerable<string> GetAllServiceName()
        {
            using (var client = GetHttpClient())
            {
                return client.GetAndReadAs<IEnumerable<string>>(CollectionStatusServiceConst.Uri_GetAllServiceName);
            }
        }

        public string GetStatus(string serviceName)
        {
            using (var client = GetHttpClient())
            {
                string uri = string.Format(CollectionStatusServiceConst.Uri_GetStatus_ClientSide, serviceName);
                return client.GetAndReadAs<string>(uri);
            }
        }
    }
}
