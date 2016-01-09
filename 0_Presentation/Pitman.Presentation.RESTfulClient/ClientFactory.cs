namespace Pitman.Presentation.RESTfulClient
{
    public static class ClientFactory
    {
        public static IServiceStatusClient CreateCollectionStatusClient(string serverAddress)
        {
            return new ServiceStatusClient(serverAddress);
        }

        public static IKLineClient CreateKLineClient(string serverAddress)
        {
            return new KLineClient(serverAddress);
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
