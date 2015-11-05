using Pitman.DistributedService.Contracts;

namespace Pitman.Presentation.RESTfulClient
{
    public static class ClientFactory
    {
        public static ICollectionStatus CreateCollectionStatusClient(string hostName)
        {
            return new CollectionStatusClient(hostName);
        }

        public static IRealTimePrice CreateRealTimePrice()
        {
            return new RealTimePriceClient();
        }
    }
}
