using Pitman.DistributedService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Presentation.RESTfulClient
{
    public static class ClientFactory
    {
        public static ICollectionStatus CreateCollectionStatusClient()
        {
            return new CollectionStatusClient();
        }

        public static IRealTimePrice CreateRealTimePrice()
        {
            return new RealTimePriceClient();
        }
    }
}
