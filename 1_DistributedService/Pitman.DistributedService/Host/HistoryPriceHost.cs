using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class HistoryPriceHost : WebHttpHost<IKLineService, KLineService>
    {
        internal HistoryPriceHost(string serverAddress)
            : base(serverAddress, KLineServiceConst.ServiceName)
        { }
    }
}
