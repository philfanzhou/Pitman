using Pitman.DistributedService.Contracts;
using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class CollectionStatusClient : RestfulClient, ICollectionStatus
    {
        public CollectionStatusClient(string serverAddress) : base(serverAddress, "CollectionStatus") { }

        public IEnumerable<string> GetAllServiceName()
        {
            using (var client = GetHttpClient())
            {
                string uri = "AllServiceName";
                return client.GetAndReadAs<IEnumerable<string>>(uri);
            }
        }

        public string GetStatus(string serviceName)
        {
            using (var client = GetHttpClient())
            {
                string uri = string.Format("Status/{0}", serviceName);
                return client.GetAndReadAs<string>(uri);
            }
        }
    }
}
