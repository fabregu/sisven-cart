using System.Web;
using System.Web.Optimization;

namespace GUIADMIN
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));                       

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundel.min.js",
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new Bundle("~/bundles/complements").Include(
                        "~/Scripts/fontawesome/all.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.responsive.js",
                        "~/Scripts/loadingoverlay/loadingoverlay.min.js",
                         "~/Scripts/sweetalert2.all.min.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery-ui-1.14.1.js",

                        "~/Scripts/scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/Datatables/css/jquery.dataTables.css",
                "~/Content/Datatables/css/responsive.dataTables.css",
                "~/Content/themes/base/jquery-ui.css"
                ));
        }
    }
}
