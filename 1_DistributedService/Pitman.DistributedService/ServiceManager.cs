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
            //Uri baseAddress = new Uri("http://127.0.0.1:9999/CollectionServiceStatus");
            //host = new ServiceHost(typeof(CollectionServiceStatus));
            //host.AddServiceEndpoint(typeof(ICollectionServiceStatus), new WebHttpBinding(), "http://127.0.0.1:9999/CollectionServiceStatus");
            //if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            //{
            //    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            //    behavior.HttpGetEnabled = true;
            //    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/CollectionServiceStatus/metadata");
            //    host.Description.Behaviors.Add(behavior);

            //    WebHttpBinding binding = new WebHttpBinding();
            //    ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ICollectionServiceStatus), binding, baseAddress);
            //    WebHttpBehavior httpBehavior = new WebHttpBehavior();
            //    endpoint.Behaviors.Add(httpBehavior);
            //}

            Uri baseAddress = new Uri("http://127.0.0.1:9999/CollectionServiceStatus");
            host = new ServiceHost(typeof(CollectionServiceStatus), baseAddress);

            WebHttpBinding binding = new WebHttpBinding();
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ICollectionServiceStatus), binding, baseAddress);
            WebHttpBehavior httpBehavior = new WebHttpBehavior();
            endpoint.Behaviors.Add(httpBehavior);

            host.Open();
        }
    }
}
