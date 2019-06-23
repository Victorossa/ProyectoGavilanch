using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGavilanch.Controllers
{
    public class AccionesController : Controller
    {
        // GET: Acciones
        public ContentResult Contenido()
        {
            return Content("Este es un resultado de Content");
        }

        //public JsonResult EnvioJson()
        //{

        //}
    }
}