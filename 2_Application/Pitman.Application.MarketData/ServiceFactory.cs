using System.Collections.Generic;

namespace Pitman.Application.MarketData
{
    public static class ServiceFactory
    {
        public static IEnumerable<IDataCollectionService> CreateAllService()
        {
            List<IDataCollectionService> services = new List<IDataCollectionService>();
            services.Add(new RealTimePriceServices());

            return services;
        }
    }
}
