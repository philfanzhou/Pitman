using Framework.DistributedService;

namespace Pitman.DistributedService
{
    public class DistributedHostManager : DistributedHostManagerBase
    {
        private static string _serverAddress = "http://localhost:9999";

        public override void Initialize()
        {
            SetStatusReportInterval(30000);

            AddHost(new CollectionStatusHost(_serverAddress));
            AddHost(new RealTimePriceHost(_serverAddress));
        }
    }
}
