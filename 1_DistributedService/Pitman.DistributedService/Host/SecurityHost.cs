using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class SecurityHost : WebHttpHost<ISecurityService, SecurityService>
    {
        internal SecurityHost(string serverAddress)
            : base(serverAddress, SecurityServiceConst.ServiceName)
        { }
    }
}
