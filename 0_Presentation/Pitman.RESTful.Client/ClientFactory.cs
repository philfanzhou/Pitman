namespace Pitman.RESTful.Client
{
    public static class ClientFactory
    {
        //public static TClient Create<TClient>(string serverAddress)
        //    where TClient : IClient
        //{
        //    if(typeof(TClient) == typeof(IKLineClient))
        //    {
        //        var client = new KLineClient(serverAddress);
        //        return (IKLineClient)client;
        //    }
        //    else
        //    {
        //        return default(TClient);
        //    }
        //}

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
