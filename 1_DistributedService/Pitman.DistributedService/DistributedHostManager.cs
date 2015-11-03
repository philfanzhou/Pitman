using Framework.DistributedService;

namespace Pitman.DistributedService
{
    public class DistributedHostManager : DistributedHostManagerBase
    {
        public override void Initialize()
        {
            SetStatusReportInterval(30000);

            AddHost(new CollectionStatusHost());
        }
    }
}
