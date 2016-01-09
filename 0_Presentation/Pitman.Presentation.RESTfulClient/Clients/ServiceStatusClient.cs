using System.Collections.Generic;

namespace Pitman.Presentation.RESTfulClient
{
    internal class ServiceStatusClient : RestfulClient, IServiceStatusClient
    {
        public ServiceStatusClient(string serverAddress) : base(serverAddress, "api") { }

        public IEnumerable<string> GetAllServiceName()
        {
            using (var client = GetHttpClient())
            {
                return client.GetAndReadAs<IEnumerable<string>>("CollectionStatus");
            }
        }

        public string GetServiceStatus(string serviceName)
        {
            using (var client = GetHttpClient())
            {
                string uri = string.Format("CollectionStatus/{0}", serviceName);
                return client.GetAndReadAs<string>(uri);
            }
        }
    }
}
