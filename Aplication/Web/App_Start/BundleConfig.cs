using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery.min.js"));*/
                        // "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/plugins/jquery/jquery.min.js",
                      "~/assets/plugins/popper/popper.min.js",
                      "~/assets/plugins/jquery-blockui/jquery.blockui.min.js",
                      "~/assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/assets/plugins/bootstrap/js/bootstrap.min.js",
                      "~/assets/plugins/datatables/jquery.dataTables.min.js",
                      "~/assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.js",
                      "~/assets/js/pages/table/table_data.js",
                      "~/assets/js/app.js",
                      "~/assets/js/layout.js",
                      "~/assets/js/theme-color.js",
                      "~/assets/plugins/material/material.min.js",
                      "~/assets/js/pages/material_select/getmdl-select.js",
                      "~/assets/plugins/material-datetimepicker/moment-with-locales.min.js",
                      "~/assets/plugins/material-datetimepicker/bootstrap-material-datetimepicker.js",
                      "~/assets/plugins/material-datetimepicker/datetimepicker.js",
                      "~/assets/plugins/dropzone/dropzone.js",
                      "~/assets/plugins/dropzone/dropzone-call.js",
                      "~/assets/js/pages/ui/animations.js"
                      ));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/fonts/material-design-icons/material-icon.css",
                      "~/fonts/font-awesome/css/font-awesome.min.css",
                      "~/assets/plugins/bootstrap/css/bootstrap.min.css",
                       "~/assets/plugins/material/material.min.css",
                      "~/assets/css/material_style.css",
                      "~/assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.css",
                     
                      "~/assets/css/pages/animate_page.css",
                      "~/assets/css/style.css",
                      "~/assets/css/plugins.min.css",
                      "~/assets/css/responsive.css",
                      "~/assets/css/theme-color.css",
                      "~/assets/plugins/dropzone/dropzone.css",
                      "~/assets/plugins/material-datetimepicker/bootstrap-material-datetimepicker.css"                      
                      ));
        }
    }
}
