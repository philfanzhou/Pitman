using Pitman.Application.DataCollection;
using Pitman.DistributedService.Contracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Pitman.DistributedService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    internal class CollectionStatusService : ICollectionStatus
    {
        [WebGet(UriTemplate = "AllServiceName", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<string> GetAllServiceName()
        {
            return CollectionServiceManager.Instance.GetAllServiceName();
        }

        [WebGet(UriTemplate = "Status/{serviceName}", ResponseFormat = WebMessageFormat.Json)]
        public string GetStatus(string serviceName)
        {
            return CollectionServiceManager.Instance.GetStatus(serviceName);
        }
    }
}
