using System.Web.Optimization;

namespace Redweb.BikeShop
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundleCollection)
        {
            bundleCollection.Add(new ScriptBundle("~/bundles/jquery").Include(
                                "~/Scripts/jquery-{version}.js"));

            bundleCollection.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                "~/Scripts/jquery.validate"));

            bundleCollection.Add(new ScriptBundle("~/bundles/modernizr").Include(
                                "~/Scripts/modernizr-*"));

            bundleCollection.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                "~/Scripts/bootstrap-paper.js",
                                "~/Scripts/respond.js"));

            bundleCollection.Add(new ScriptBundle("~/bundles/css").Include(
                                "~/Content/bootstrap.css",
                                "~/Content/site.css"));
        }
    }
}