using BOL;
using ClosedXML.Excel;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.Mvc;

namespace GUIADMIN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Usuario()
        {
            return View();

        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();
            oLista = new BOL_Usuarios().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.IdUsuario == 0)
            {
                resultado = new BOL_Usuarios().RegistrarUsuario(obj, out mensaje);
            }
            else
            {
                resultado = new BOL_Usuarios().EditarUsuario(obj, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new BOL_Usuarios().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaReporte(string fechaInicio, string fechaFin, string idTransaccion)
        {
            List<Reporte> oLista = new List<Reporte>();
            oLista = new BOL_Reportes().Ventas(fechaInicio, fechaFin, idTransaccion);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult VistaDashboard()
        {
            Dashboard resultado = new BOL_Reportes().VerDashboard();
            return Json(new { dashboard = resultado }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public FileResult ExportarVenta(string fechaInicio, string fechaFin, string idTransaccion)
        {
            List<Reporte> oLista = new List<Reporte>();
            oLista = new BOL_Reportes().Ventas(fechaInicio, fechaFin, idTransaccion);

            DataTable dt = new DataTable();
            dt.Locale = new CultureInfo("es-PE");
            dt.Columns.Add("Fecha Venta", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Id Transaccion", typeof(string));

            foreach (Reporte rp in oLista)
            {
                dt.Rows.Add(rp.FechaVenta,
                            rp.Cliente,
                            rp.Producto,
                            rp.Precio,
                            rp.Cantidad,
                            rp.Total,
                            rp.IdTransaccion);
            }

            dt.TableName = "Datos";

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    string nombreArchivo = "ReporteVentas";
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreArchivo + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }
    }
}