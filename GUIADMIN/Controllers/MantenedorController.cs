using BOL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIADMIN.Controllers
{
    public class MantenedorController : Controller
    {       
        // GET: Mantenedor
        public ActionResult Categoria()
        {
            return View();
        }public ActionResult Marca()
        {
            return View();
        }public ActionResult Producto()
        {
            return View();
        }

        #region Categoria
        [HttpGet]
        public JsonResult ListarCategorias()
        {
            List<Categoria> oLista = new List<Categoria>();
            oLista = new BOL_Categorias().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarCategoria(Categoria obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.IdCategoria == 0)
            {
                resultado = new BOL_Categorias().RegistrarCategoria(obj, out mensaje);
            }
            else
            {
                resultado = new BOL_Categorias().EditarCategoria(obj, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new BOL_Categorias().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Marca
        [HttpGet]
        public JsonResult ListarMarcas()
        {
            List<Marca> oLista = new List<Marca>();
            oLista = new BOL_Marcas().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarMarca(Marca obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.IdMarca == 0)
            {
                resultado = new BOL_Marcas().RegistrarMarca(obj, out mensaje);
            }
            else
            {
                resultado = new BOL_Marcas().EditarMarca(obj, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            respuesta = new BOL_Marcas().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}