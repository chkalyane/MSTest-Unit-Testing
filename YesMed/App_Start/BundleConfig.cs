using System.Web;
using System.Web.Optimization;

namespace YesMed
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/scripts/libraries/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/scripts/libraries/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
                      "~/Assets/scripts/libraries/angular.min.js",
                      "~/Assets/scripts/libraries/angular-ui-router.js"));

            bundles.Add(new ScriptBundle("~/bundles/product").Include(
                "~/Assets/scripts/controllers/productCtrl.js",
                "~/Assets/scripts/services/productService.js"));

            bundles.Add(new ScriptBundle("~/bundles/category").Include(
          "~/Assets/scripts/controllers/categoryCtrl.js",
          "~/Assets/scripts/services/categoryService.js"));

            bundles.Add(new ScriptBundle("~/bundles/user").Include(
              "~/Assets/scripts/controllers/userCtrl.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assets/scripts/libraries/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assets/scripts/libraries/bootstrap.js",
                      "~/Assets/scripts/libraries/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Assets/css/bootstrap.css",
                      "~/Assets/css/site.css",
                      "~/Assets/css/common.css"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                      "~/Assets/scripts/app.js"));
        }
    }
}
