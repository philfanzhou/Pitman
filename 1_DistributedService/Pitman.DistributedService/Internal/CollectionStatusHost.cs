using Framework.DistributedService;
using Pitman.DistributedService.Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Pitman.DistributedService
{
    internal class CollectionStatusHost : ServiceHost, IDistributedHost
    {
        private static Uri baseAddress = new Uri("http://localhost:9999/CollectionService");
        
        public string Name
        {
            get
            {
                return "CollectionStatus";
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
