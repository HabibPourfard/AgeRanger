using System.Web;
using System.Web.Optimization;

namespace AgeRanger.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/All").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-messages.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/app/app.js",
                "~/app/services/*.js",
                "~/app/components/home/*.js",
                "~/app/components/person/*.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}
