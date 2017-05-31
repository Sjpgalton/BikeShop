using System.Web.Mvc;
using System.Web.Routing;

namespace Redweb.BikeShop.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            routeCollection.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routeCollection.LowercaseUrls = true;

            routeCollection.Add("ProductDetails", 
                new SeoFriendlyRoute("Products/ProductDetails/{id}",
                new RouteValueDictionary(new { controller = "Products", action = "ProductDetails" }),
                new MvcRouteHandler()));

            routeCollection.Add("SearchProductDetails",
                new SeoFriendlyRoute("Products/ProductDetails/{id}",
                    new RouteValueDictionary(new { controller = "Products", action = "SearchProductDetails" }),
                    new MvcRouteHandler()));

            routeCollection.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}