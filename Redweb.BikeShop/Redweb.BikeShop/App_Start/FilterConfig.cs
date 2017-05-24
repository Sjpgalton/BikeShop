using System.Web.Mvc;

namespace Redweb.BikeShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new HandleErrorAttribute());
        }
    }
}