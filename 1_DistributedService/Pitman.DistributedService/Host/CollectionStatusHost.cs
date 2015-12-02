using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class CollectionStatusHost : WebHttpHost<ICollectionStatusService, CollectionStatusService>
    {
        internal CollectionStatusHost(string serverAddress)
            : base(serverAddress, CollectionStatusServiceConst.ServiceName)
        { }
    }
}
