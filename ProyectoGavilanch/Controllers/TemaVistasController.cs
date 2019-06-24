using ModeloDatos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGavilanch.Controllers
{
    public class TemaVistasController : Controller
    {
        private BD_ProyectoGavilanchContext db = new BD_ProyectoGavilanchContext();
        private productos producto = new productos();

        public ActionResult MiAction()
        {
            return View();
        }

        public ActionResult CargaLista()
        {
            ViewBag.ListaProductos = producto.Listar();
            return View();
        }
    }
}