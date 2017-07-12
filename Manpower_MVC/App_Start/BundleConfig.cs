using System.Web;
using System.Web.Optimization;

namespace Manpower_MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.css")
                .Include("~/Content/css/select2.css")
                .Include("~/Content/css/datepicker3.css")
                .Include("~/Content/css/AdminLTE.css")
                .Include("~/Content/css/skins/skin-blue.css")
                .Include("~/Content/css/DataTables/dataTable.fontAwesome.css")
                .Include("~/Content/css/Site.css")
                .Include("~/Content/css/DataTables/KeyTable/dataTables.bootstrap.css")
                .Include("~/Content/css/DataTables/Buttons-1.3.1/buttons.bootstrap.css")
                .Include("~/Content/css/DataTables/Select-1.2.2/select.bootstrap.css")
                .Include("~/Content/css/DataTables/DataTableEdit/editor.bootstrap.css")
                .Include("~/Content/css/DataTables/Buttons-1.3.1/buttons.dataTables.css")
                .Include("~/Content/css/DataTables/KeyTable/keyTable.dataTables.css")
                .Include("~/Content/css/DataTables/DataTableEdit/editor.dataTables.css")
                .Include("~/Content/css/DataTables/DataTables.Checkboxes-1.2.6/dataTables.checkboxes.css")
                );

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-2.2.4.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/select2/select2.full.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator/validator.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/app.js")
                .Include("~/Content/js/init.js")
                .Include("~/Content/js/DataTables/jquery.dataTables.js")
                .Include("~/Content/js/DataTables/Buttons-1.3.1/dataTables.buttons.js")
                .Include("~/Content/js/DataTables/Select/dataTables.select.js")
                .Include("~/Content/js/DataTables/KeyTable/dataTables.keyTable.js")
                .Include("~/Content/js/DataTables/DataTableEdit/dataTables.editor.js")
                .Include("~/Content/js/DataTables/Buttons-1.3.1/buttons.print.js")
                .Include("~/Content/js/DataTables/Buttons-1.3.1/buttons.bootstrap.js")
                .Include("~/Content/js/DataTables/DataTables.Checkboxes-1.2.6/dataTables.checkboxes.js")
                );
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
