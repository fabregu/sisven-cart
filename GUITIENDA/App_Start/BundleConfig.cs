using System.Web;
using System.Web.Optimization;

namespace GUITIENDA
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
                         
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundel.js"));           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                "~/Content/DataTable/css/jquery.dataTable.css",
                "~/Content/DataTable/css/responsive/dataTable.css",
                "~/Content/sweetalert.css"
                ));
        }
    }
}
