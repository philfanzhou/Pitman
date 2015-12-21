using System.Collections.Generic;
using System.ServiceModel;

namespace Pitman.DistributedService.Contracts
{
    [ServiceContract]
    public interface ISecurityService
    {
        [OperationContract]
        IEnumerable<SecurityDto> GetAll();
    }
}
