using Framework.DistributedService;
using Pitman.DistributedService.Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Pitman.DistributedService
{
    internal class CollectionStatusHost : ServiceHost, IDistributedHost
    {
        private static Uri baseAddress = new Uri("http://127.0.0.1:9999/CollectionServiceStatus");
        
        public string Name
        {
            get
            {
                return "CollectionStatusService";
            }
        }

        internal CollectionStatusHost() : base(typeof(CollectionStatusService), baseAddress)
        {
            WebHttpBinding binding = new WebHttpBinding();
            ServiceEndpoint endpoint = AddServiceEndpoint(typeof(ICollectionStatus), binding, baseAddress);
            WebHttpBehavior httpBehavior = new WebHttpBehavior();
            endpoint.Behaviors.Add(httpBehavior);
        }
    }
}
