using System.Web.Optimization;

namespace SARCEM_TCC.web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/TableExport/xlsx.core.js",
                        "~/Scripts/TableExport/FileSaver.js",
                        "~/Scripts/jquery-{version}.js",

                        "~/Scripts/bootstrap.js",
                        "~/scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/scripts/datatables/datatablesV1.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/scripts/TableExport/tableexport.js",
                        "~/scripts/select2.js"




                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                         ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                      "~/Content/bootstrap-theme.css",
                       "~/content/datatables/css/datatables.bootstrap.css",
                        "~/content/datatables/css/datatablesV1.css",
                      "~/Content/select2.css",
                      "~/Content/select2-bootstrap.css",
                    "~/content/tableexport/tableexport.css",
                    "~/Content/bootstrapSlate.css",
                      "~/Content/Site.css",
                      "~/Content/Site2.css"));
        }
    }
}
