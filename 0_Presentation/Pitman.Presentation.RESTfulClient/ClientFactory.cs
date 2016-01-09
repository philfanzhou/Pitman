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

        public static IKLineClient CreateKLineClient(string serverAddress)
        {
            return new KLineClient(serverAddress);
        }

        public static IIntradayService CreateIntradayClient(string serverAddress)
        {
            return new IntradayClient(serverAddress);
        }

        public static ISecurityClient CreateSecurityService(string serverAddress)
        {
            return new SecurityClient(serverAddress);
        }

        public static IStockBonusClient CreateStockBonusClient(string serverAddress)
        {
            return new StockBonusClient(serverAddress);
        }

        public static IStockProfileClient CreateStockProfileClient(string serverAddress)
        {
            return new StockProfileClient(serverAddress);
        }

        public static IStockStructureClient CreateStockStructureClient(string serverAddress)
        {
            return new StockStructureClient(serverAddress);
        }
    }
}
