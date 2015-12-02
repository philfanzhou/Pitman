using Pitman.DistributedService.Contracts;

namespace Pitman.Presentation.RESTfulClient
{
    public static class ClientFactory
    {
        public static ICollectionStatusService CreateCollectionStatusClient(string serverAddress)
        {
            return new CollectionStatusClient(serverAddress);
        }

        public static IRealTimeService CreateRealTimePrice(string serverAddress)
        {
            return new RealTimeClient(serverAddress);
        }

        public static IKLineService CreateHistoryPriceClient(string serverAddress)
        {
            return new KLineClient(serverAddress);
        }
    }
}
