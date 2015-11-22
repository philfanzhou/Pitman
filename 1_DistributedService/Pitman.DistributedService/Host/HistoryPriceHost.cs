using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class HistoryPriceHost : WebHttpHost<IHistoryPrice, HistoryPriceService>
    {
        internal HistoryPriceHost(string serverAddress)
            : base(serverAddress, HistoryPriceConst.ServiceName)
        { }
    }
}
