using ModeloDatos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGavilanch.Controllers
{
    public class HomeController : Controller
    {
        private BD_ProyectoGavilanchContext db = new BD_ProyectoGavilanchContext();
        private productos producto = new productos();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //Codigo para que la parcial funcione
            ViewBag.ListaProductos = producto.Listar();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}