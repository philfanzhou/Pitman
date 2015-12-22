using System.Web.Http;

namespace Pitman.WebApi
{
    public static class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //        name: "StockCode",
            //        routeTemplate: "api/{controller}/{stockCode}",
            //        defaults: new
            //        {
            //            //controller = "StockBonus",
            //            //action = "Get"
            //        }
            //    );


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
