using System.Web;
using System.Web.Optimization;

namespace ESys
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/js").Include(
                        "~/Content/Custom_js/jquery-3.2.1.slim.min.js",
                        "~/Content/Custom_js/jquery-3.2.1.min.js",
                        "~/Content/Custom_js/popper.min.js",
                        "~/Content/Custom_js/bootstrap4.min.js"
                        ));
            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/Custom_css/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css").Include(
                     "~/Content/Custom_css/bootstrap4.min.css"
                     , "~/Content/Custom_css/ESys_Style.css"
                     , "~/Content/Custom_css/font-awesome.min.css"
                     ));
        }
    }
}
