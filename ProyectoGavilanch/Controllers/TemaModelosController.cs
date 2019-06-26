using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGavilanch.Controllers
{
    public class TemaModelosController : Controller
    {
        // GET: TemaModelos
        public ActionResult Index()
        {
            return View();
        }


        //aquí vemos varias sobrecargas el Action, el nombre del controlador, y el mensaje de error
        public JsonResult DivisibleEntre2(int NumeroDivisibleEntre2)
        {
            var esValido = NumeroDivisibleEntre2 % 2 == 0;
            return Json(esValido, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index2()
        {
            return View();
        }
    }
}