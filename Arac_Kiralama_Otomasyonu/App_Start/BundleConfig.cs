using System.Web;
using System.Web.Optimization;

namespace Arac_Kiralama_Otomasyonu
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/template/js/jquery-3.4.1.min.js",
                      "~/template/js/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/template/css/bootstrap.css",
                      "~/template/css/site.css",
                      "~/template/css/bootstrap.min.css",
                      "~/template/css/sablonum.css",
                      "~/template/css/responsive.css",
                      "~/template/css/style.css",
                      "~/template/css/style.scss",
                      "~/template/css/style.css.map"));
                      
                  
        }
    }
}
