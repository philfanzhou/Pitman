using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class RealTimePriceHost : WebHttpHost<IRealTimeService, RealTimeService>
    {
        internal RealTimePriceHost(string serverAddress)
            : base(serverAddress, Contracts.RealTimeService.ServiceName)
        { }
    }
}
