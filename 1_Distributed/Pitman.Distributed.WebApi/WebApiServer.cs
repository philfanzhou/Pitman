using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Pitman.Distributed.WebApi
{
    public class WebApiServer
    {
        private HttpSelfHostServer _httpServer;

        public void Open(int port)
        {
            var configuration = new HttpSelfHostConfiguration(string.Format("http://localhost:{0}", port));
            _httpServer = new HttpSelfHostServer(configuration);

            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                    name: "CollectionStatus",
                    routeTemplate: "api/CollectionStatus/{serviceName}",
                    defaults: new
                    {
                        controller = "CollectionStatus",
                        serviceName = RouteParameter.Optional
                    }
                );

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{stockCode}",
                defaults: new
                {
                    stockCode = RouteParameter.Optional
                }
            );

            _httpServer.OpenAsync();
        }
    }
}
