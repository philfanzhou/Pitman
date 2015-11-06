using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class CollectionStatusClient : RestfulClient, ICollectionStatus
    {
        public CollectionStatusClient(string serverAddress) : base(serverAddress, CollectionStatusConst.ServiceName) { }

        public IEnumerable<string> GetAllServiceName()
        {
            using (var client = GetHttpClient())
            {
                return client.GetAndReadAs<IEnumerable<string>>(CollectionStatusConst.Uri_GetAllServiceName);
            }
        }

        public string GetStatus(string serviceName)
        {
            using (var client = GetHttpClient())
            {
                string uri = string.Format(CollectionStatusConst.Uri_GetStatus_ClientSide, serviceName);
                return client.GetAndReadAs<string>(uri);
            }
        }
    }
}
