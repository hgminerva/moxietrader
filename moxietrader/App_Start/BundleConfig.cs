using System.Web;
using System.Web.Optimization;

namespace moxietrader
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            // Template styles
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/bootstrap-theme.min.css",
                      "~/css/plugins.css",
                      "~/css/opensans-web-font.css",
                      "~/css/montserrat-web-font.css",
                      "~/css/font-awesome.min.css",
                      "~/css/style.css",
                      "~/css/responsive.css",
                      "~/css/toastr.css",
                      "~/css/ytLoad.jquery.css",
                      "~/amcharts/amcharts/style.css"));

            // Template modernizer
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"));

            // Template bootstrap/jquery
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/vendor/jquery-1.11.2.min.js",
                      "~/js/vendor/bootstrap.min.js",
                      "~/js/vendor/toastr.js",
                      "~/js/vendor/date.js",
                      "~/js/vendor/jquery.transit.js",
                      "~/js/vendor/ytLoad.jquery.js"));

            // Template script
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/js/plugins.js",
                        "~/js/main.js"));

            // Chart View Page
            bundles.Add(new StyleBundle("~/bundles/chart").Include(
                      "~/css/chart.css"));

            // AMCharts
            bundles.Add(new ScriptBundle("~/bundles/amchart").Include(
                        "~/amcharts/amcharts/amcharts.js",
                        "~/amcharts/amcharts/serial.js",
                        "~/amcharts/amcharts/amstock.js"));
        }
    }
}
