using Pitman.DistributedService.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract(Name = "CollectionServiceStatus", Namespace = "http://pitman.quantum.com/")]
    public interface ICollectionServiceStatus
    {
        [OperationContract]
        CollectionServiceStatusDto GetStatus(string serviceName);

        [OperationContract]
        IEnumerable<string> GetAllServiceName();
    }
}
