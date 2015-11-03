using Pitman.DistributedService.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface ICollectionStatus
    {
        [OperationContract]
        string GetStatus(string serviceName);

        [OperationContract]
        IEnumerable<string> GetAllServiceName();
    }
}
