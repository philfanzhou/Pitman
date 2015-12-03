using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class RealTimeHost : WebHttpHost<IRealTimeService, RealTimeService>
    {
        internal RealTimeHost(string serverAddress)
            : base(serverAddress, RealTimeServiceConst.ServiceName)
        { }
    }
}
