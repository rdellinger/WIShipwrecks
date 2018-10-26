using System.Web;
using System.Web.Optimization;

namespace WIShipwrecks
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/WIShipwrecks.css"));
            
            // My custom CSS
            bundles.Add(new StyleBundle("~/Content/detailscss").Include(
                      "~/Content/details.min.css",
                      "~/Content/details-theme.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapformcss").Include(
                      "~/Content/bootstrap_form.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                      "~/Content/bootstrap.css"));

            // My custom JS
            bundles.Add(new ScriptBundle("~/bundles/WIShipwrecks").Include(
                      "~/Scripts/tabHash.js"));

            
            // Solido CSS
            bundles.Add(new StyleBundle("~/Content/solidocss").Include(
                     "~/Content/solido/css/normalize.css",
                     "~/Content/solido/css/main.css",
                     "~/Content/solido/css/solido.css",
                     "~/Content/solido/css/isotope.css",
                     "~/Content/solido/css/responsive.css",
                     "~/Content/solido/css/vegas/jquery.vegas.css",
                     "~/Content/solido/css/popup/magnific-popup.css",
                     "~/Content/solido/js/superslides-0.6.2/dist/stylesheets/superslides.css",
                     "~/Content/solido/css/color/dark.css",
                     "~/Content/solido/css/color/black.css",
                     "~/Content/solido/css/color/green.css",
                     "~/Content/solido/css/color/red.css",
                     "~/Content/solido/css/color/yellow.css",
                     "~/Content/solido/css/color/purple.css",
                     "~/Content/solido/css/color/turquoise.css",
                     "~/Content/solido/css/color/orange.css",
                     "~/Content/solido/css/color/blue.css"));


            // Solido JS
            bundles.Add(new ScriptBundle("~/bundles/solido").Include(
                        //"~/Content/solido/js/jquery.min.js",
                        "~/Content/solido/js/jquery-ui.min.js",
                        "~/Content/solido/js/jquery.carouFredSel-6.2.1-packed.js",
                        "~/Content/solido/js/jquery.smoothwheel.js",
                        "~/Content/solido/js/main.js",
                        "~/Content/solido/js/jquery.inview.js",
                        "~/Content/solido/js/jquery.sticky.js",
                        "~/Content/solido/js/caroussel/jquery.easing.1.3.js",
                        "~/Content/solido/js/portfolio.js",
                        "~/Content/solido/js/superslides-0.6.2/dist/jquery.superslides.js",
                        "~/Content/solido/js/jquery.hoverdir.js",
                        "~/Content/solido/js/jquery.nav.js",
                        "~/Content/solido/js/popup/jquery.magnific-popup.js",
                        "~/Content/solido/js/caroussel/jquery.contentcarousel.js",
                        "~/Content/solido/js/jquery.isotope.min.js",
                        "~/Content/solido/js/plugins.js",
                        "~/Content/solido/js/jquery.validate.js",
                        "~/Content/solido/js/jquery.form.js",
                        "~/Content/solido/js/test.js"));




            // Enable bundling and minification
            BundleTable.EnableOptimizations = true;

        }
    }
}
