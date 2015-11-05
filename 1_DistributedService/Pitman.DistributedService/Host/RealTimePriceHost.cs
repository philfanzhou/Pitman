using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class RealTimePriceHost : WebHttpHost<IRealTimePrice, RealTimePriceService>
    {
        internal RealTimePriceHost(string serverAddress)
            : base(serverAddress, "RealTimePrice")
        { }
    }
}
