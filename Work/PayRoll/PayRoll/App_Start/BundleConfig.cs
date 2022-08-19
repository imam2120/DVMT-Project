using System.Web;
using System.Web.Optimization;

namespace PayRoll
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                //"~/Scripts/jquery-{version}.js"
                     "~/Scripts/jquery-1.10.2.min.js",
                     "~/Scripts/jquery.dataTables.js",
                     "~/Scripts/1.10.2-jquery-ui.min.js"                             
                     ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
                
                "~/Scripts/assets/js/plugins/loaders/pace.min.js",
                //"~/Scripts/assets/js/core/libraries/jquery.min.js",
                "~/Scripts/assets/js/core/libraries/bootstrap.min.js",
                "~/Scripts/assets/js/plugins/loaders/blockui.min.js",
                "~/Scripts/assets/js/plugins/ui/nicescroll.min.js",
                "~/Scripts/assets/js/plugins/ui/drilldown.js",
                "~/Scripts/assets/js/plugins/forms/selects/select2.min.js",
                "~/Scripts/assets/js/plugins/forms/selects/bootstrap_multiselect.js",
                "~/Scripts/assets/js/plugins/forms/styling/uniform.min.js",
                "~/Scripts/assets/js/plugins/forms/styling/switchery.min.js",
                "~/Scripts/assets/js/plugins/ui/moment/moment.min.js",
                "~/Scripts/assets/js/plugins/pickers/daterangepicker.js",
                "~/Scripts/assets/js/plugins/tables/datatables/datatables.min.js",
                "~/Scripts/assets/js/plugins/notifications/bootbox.min.js",
                "~/Scripts/assets/js/plugins/notifications/sweet_alert.min.js",
                "~/Scripts/assets/js/pages/components_modals.js",
                 "~/Scripts/assets/js/pages/form_layouts.js",
               
                //"~/Scripts/assets/js/plugins/visualization/echarts/echarts.js",
                //"~/Scripts/assets/js/charts/echarts/pies_donuts.js",
                 "~/Scripts/assets/js/core/app.js",
                  //"~/Scripts/assets/js/pages/datatables_sorting.js",
                "~/Scripts/assets/js/pages/navbar_components.js",                               
                "~/Scripts/mustache.js",
               
                 "~/Scripts/site.common.js",
                "~/Scripts/toastr.min.js",
               
                "~/Scripts/chosen.jquery.js"
                
                ));

            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/jquery.dataTables.css",
                     "~/Scripts/assets/css/icons/fontawesome/styles.min.css",
                      "~/Scripts/assets/css/icons/icomoon/styles.css",
                      "~/Scripts/assets/css/bootstrap.css",
                      "~/Scripts/assets/css/core.css",
                      "~/Scripts/assets/css/components.css",
                      "~/Scripts/assets/css/colors.css",
                       "~/Content/toastr.min.css"
                    

                      ));
        }
    }
}
