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
            AddHost(new RealTimeHost(_serverAddress));
            AddHost(new KLineHost(_serverAddress));
            AddHost(new IntradayHost(_serverAddress));
            AddHost(new SecurityHost(_serverAddress));
        }
    }
}
