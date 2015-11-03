using Pitman.DistributedService.Dto;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface ICollectionServiceStatus
    {
        [OperationContract]
        CollectionServiceStatusDto GetStatus(string serviceName);

        [OperationContract]
        IEnumerable<string> GetAllServiceName();
    }
}
