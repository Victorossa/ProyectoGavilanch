using ModeloDatos.Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGavilanch.Controllers
{
    public class AccionesController : Controller
    {
        private BD_ProyectoGavilanchContext db = new BD_ProyectoGavilanchContext();
        private productos producto = new productos();


        // GET: Acciones
        public ContentResult Contenido()
        {
            return Content("Este es un resultado de Content");
        }

        public JsonResult EnvioJson()
        {
            var prod = new productos();
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        public RedirectResult Redireccion()
        {
            return Redirect("http://google.com");
        }

        public RedirectToRouteResult RedireccionAAccion()
        {
            return RedirectToAction("Contenido", "Acciones");
        }

        public FileResult DescargaArchivo()
        {
            var ruta = Server.MapPath("~/diploma-mongodb-redis.pdf");
            return File(ruta, "application/pdf", "diploma.pdf");
        }

        public ActionResult QueryString(string nombre, int? edad)
        {
            //localhost:63650/Acciones/QueryString?nombre=Victor&edad=38
            ViewBag.Message = "El nombre que se va a mostrar es : " + nombre + ", Edad: " + edad.ToString();
            return View();
        }

        [HttpGet]
        public ActionResult MetodoGetPost()
        {
            ViewBag.Message = "Valor Entero presentado por Post: ";
            return View();
        }

        [HttpPost]
        public ActionResult MetodoGetPost(int valor)
        {
            ViewBag.Message = "Valor Entero presentado por Post: " + valor;
            return View();
        }

        public ActionResult ViewBagViewData()
        {
            ViewBag.Message = "Texto enviado por ViewBag";
            ViewBag.UnEntero = 2018;
            ViewBag.UnaFecha = new DateTime(2019, 07, 16);

            ViewData["Texto"] = "Texto Enviado por ViewData";
            ViewData["Entero"] = 2019;
            ViewData["Fecha"] = new DateTime(2018, 07, 16);

            return View();
        }
    }
}