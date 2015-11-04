using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Presentation.RESTfulClient
{
    internal class CollectionStatusClient : ICollectionStatus
    {
        public IEnumerable<string> GetAllServiceName()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://quantum1234.cloudapp.net:6688/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = client.GetAsync("collectionservicestatus/allservicename").Result.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<IEnumerable<string>>().Result;
            }
        }

        public string GetStatus(string serviceName)
        {
            throw new NotImplementedException();
        }
    }
}
