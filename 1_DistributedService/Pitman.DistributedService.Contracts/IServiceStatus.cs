using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface IServiceStatus
    {
        [OperationContract]
        bool IsAlive(string serviceName);

        [OperationContract]
        IEnumerable<string> GetAllServiceName();
    }
}
