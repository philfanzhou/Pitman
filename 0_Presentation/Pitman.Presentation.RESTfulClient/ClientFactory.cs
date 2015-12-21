using Pitman.DistributedService.Contracts;

namespace Pitman.Presentation.RESTfulClient
{
    public static class ClientFactory
    {
        public static ICollectionStatusService CreateCollectionStatusClient(string serverAddress)
        {
            return new CollectionStatusClient(serverAddress);
        }

        public static IRealTimeService CreateRealTimeClient(string serverAddress)
        {
            return new RealTimeClient(serverAddress);
        }

        public static IKLineService CreateKLineClient(string serverAddress)
        {
            return new KLineClient(serverAddress);
        }

        public static IIntradayService CreateIntradayClient(string serverAddress)
        {
            return new IntradayClient(serverAddress);
        }

        public static ISecurityService CreateSecurityService(string serverAddress)
        {
            return new SecurityClient(serverAddress);
        }
    }
}
