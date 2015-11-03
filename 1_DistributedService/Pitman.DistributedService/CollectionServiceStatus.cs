using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
using System.Collections.Generic;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    public class CollectionServiceStatus : ICollectionServiceStatus
    {
        [WebGet(UriTemplate = "/AllServiceName", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetAllServiceName()
        {
            return new List<string> { "Test ok" };
        }

        public CollectionServiceStatusDto GetStatus(string serviceName)
        {
            return CollectionServiceStatusDto.Running;
        }
    }
}
