using BOL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIADMIN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        
        }public ActionResult Usuario()
        {
            return View();
        
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oLista = new List<Usuario>();
            oLista = new BOL_Usuarios().Listar();

            return Json(oLista, JsonRequestBehavior.AllowGet);
        }
    }
}