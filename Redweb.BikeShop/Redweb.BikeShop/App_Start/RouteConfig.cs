using System.Web.Mvc;
using System.Web.Routing;

namespace Redweb.BikeShop.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            routeCollection.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routeCollection.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}