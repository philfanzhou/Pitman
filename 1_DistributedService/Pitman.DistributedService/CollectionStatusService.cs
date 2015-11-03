using Pitman.DistributedService.Contracts;
using Pitman.DistributedService.Dto;
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

        public CollectionStatusDto GetStatus(string serviceName)
        {
            return CollectionStatusDto.Running;
        }
    }
}
