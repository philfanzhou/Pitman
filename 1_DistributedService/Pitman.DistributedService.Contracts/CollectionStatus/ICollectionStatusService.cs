using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface ICollectionStatusService
    {
        [OperationContract]
        string GetStatus(string serviceName);

        [OperationContract]
        IEnumerable<string> GetAllServiceName();
    }
}
