using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class KLineHost : WebHttpHost<IKLineService, KLineService>
    {
        internal KLineHost(string serverAddress)
            : base(serverAddress, KLineServiceConst.ServiceName)
        { }
    }
}
