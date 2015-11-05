using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class CollectionStatusHost : WebHttpHost<ICollectionStatus, CollectionStatusService>
    {
        internal CollectionStatusHost(string serverAddress)
            : base(serverAddress, "CollectionStatus")
        { }
    }
}
