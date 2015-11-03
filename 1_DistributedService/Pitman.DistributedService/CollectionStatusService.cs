using Pitman.DistributedService.Contracts;
using System.Collections.Generic;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    internal class CollectionStatusService : ICollectionStatus
    {
        [WebGet(UriTemplate = "/AllServiceName", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetAllServiceName()
        {
            return new List<string> { "Test ok" };
        }

        public string GetStatus(string serviceName)
        {
            return "GetStatus ok";
        }
    }
}
