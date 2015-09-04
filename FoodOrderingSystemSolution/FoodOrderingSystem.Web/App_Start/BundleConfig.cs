using System.Web;
using System.Web.Optimization;

namespace FoodOrderingSystem.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bookblock.min.js",
                      "~/Scripts/bookshelf.js",
                      "~/Scripts/boxlayout.js",
                      "~/Scripts/classie.js",
                      "~/Scripts/gridmvc.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bookblock.css",
                      "~/Content/component.css",
                      "~/Content/demo.css",
                      "~/Content/normalize.css",
                      "~/Content/Site.css",
                      "~/Content/Gridmvc.css"));
        }
    }
}
