using Pitman.DistributedService.Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Pitman.DistributedService
{
    public class ServiceManager
    {
        private ServiceHost host;

        public void OpenAllService()
        {
            host = new ServiceHost(typeof(CollectionServiceStatus));
            host.AddServiceEndpoint(typeof(ICollectionServiceStatus), new WSHttpBinding(), "http://127.0.0.1:9999/CollectionServiceStatus");
            if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                behavior.HttpGetEnabled = true;
                behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/CollectionServiceStatus/metadata");
                host.Description.Behaviors.Add(behavior);
            }

            host.Open();
        }
    }
}
