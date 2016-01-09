using System.Web.Http;

namespace Pitman.Distributed.WebApi
{
    public static class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                    name: "CollectionStatus",
                    routeTemplate: "api/CollectionStatus/{serviceName}",
                    defaults: new
                    {
                        controller = "CollectionStatus",
                        serviceName = RouteParameter.Optional
                    }
                );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{stockCode}",
                defaults: new
                {
                    stockCode = RouteParameter.Optional
                }
            );
        }
    }
}
