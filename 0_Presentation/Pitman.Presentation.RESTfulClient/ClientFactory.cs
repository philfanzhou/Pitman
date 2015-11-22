using Pitman.DistributedService.Contracts;

namespace Pitman.Presentation.RESTfulClient
{
    public static class ClientFactory
    {
        public static ICollectionStatus CreateCollectionStatusClient(string serverAddress)
        {
            return new CollectionStatusClient(serverAddress);
        }

        public static IRealTimePrice CreateRealTimePrice(string serverAddress)
        {
            return new RealTimePriceClient(serverAddress);
        }

        public static IHistoryPrice CreateHistoryPriceClient(string serverAddress)
        {
            return new HistoryPriceClient(serverAddress);
        }
    }
}
