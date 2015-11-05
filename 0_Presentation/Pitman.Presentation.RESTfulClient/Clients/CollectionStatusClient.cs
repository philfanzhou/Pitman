using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Pitman.Presentation.RESTfulClient
{
    internal class CollectionStatusClient : ICollectionStatus
    {
        private static string _hostName = "CollectionStatus";

        public IEnumerable<string> GetAllServiceName()
        {
            using (var client = new RestfulClient())
            {
                client.BaseAddress = new Uri("http://localhost:9999/");

                string uri = "collectionservice/allservicename";
                return client.GetAndReadAs<IEnumerable<string>>(uri);
            }
        }

        public string GetStatus(string serviceName)
        {
            using (var client = new RestfulClient())
            {
                client.BaseAddress = new Uri("http://localhost:9999/");

                string uri = string.Format("collectionservice/Status/{0}", serviceName);
                return client.GetAndReadAs<string>(uri);
            }
        }
    }
}
