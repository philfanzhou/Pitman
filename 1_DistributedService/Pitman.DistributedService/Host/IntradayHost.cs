using Framework.DistributedService;
using Pitman.DistributedService.Contracts;

namespace Pitman.DistributedService
{
    internal class IntradayHost : WebHttpHost<IIntradayService, IntradayService>
    {
        internal IntradayHost(string serverAddress)
            : base(serverAddress, IntradayServiceConst.ServiceName)
        { }
    }
}
