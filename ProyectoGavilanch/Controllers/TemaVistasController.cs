using ModeloDatos.Datos;
using ProyectoGavilanch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
namespace ProyectoGavilanch.Controllers
{
    public class TemaVistasController : Controller
    {
        private BD_ProyectoGavilanchContext db = new BD_ProyectoGavilanchContext();
        private productos producto = new productos();
        private peliculas peliculas = new peliculas();

        public ActionResult MiAction()
        {
            return View();
        }

        public ActionResult CargaLista()
        {
            ViewBag.ListaProductos = producto.Listar();
            return View();
        }

        public ActionResult CargarPeliculas()
        {
            var model = peliculas.ListarPeliculas();
            return View(model);
        }

        public ActionResult CargarPeliculasConRaw()
        {
            var model = peliculas.ListarPeliculas();
            return View(model);
        }

        public ActionResult RenderActionYAction()
        {
            return View();
        }

        public ActionResult DisplayYDisplayTemplates()
        {
            var pelicula = (from p in db.Peliculas where p.EstaEnCartelera == true select p).First();
            ViewBag.Propiedad = pelicula;
            return View();
        }

        public ActionResult EditorTemplates()
        {
            var pelicula = (from p in db.Peliculas where p.EstaEnCartelera == true select p).First();
            ViewBag.Propiedad = pelicula;
            return View();
        }

        public ActionResult DropDownEnVista()
        {
            ViewBag.Listado = ObtenerListado();
            return View();
        }

        public List<SelectListItem> ObtenerListado()
        {
            return new List<SelectListItem>() {
            new SelectListItem() { Text="Valor 1", Value="1" },
            new SelectListItem() { Text="Valor 2", Value="2" },
            new SelectListItem() { Text="Valor 3", Value="3",Disabled = true},
            new SelectListItem() { Text="Valor 4", Value="4" },
            new SelectListItem() { Text="Valor 5", Value="5" }};
        }

        public ActionResult DropDownDesdeUnEnum()
        {
            ViewBag.MiListadoEnum = ToListSelectListItem<ResultadoOperacion>();
            return View();
        }


        private List<SelectListItem> ToListSelectListItem<T>()
        {
            var t = typeof(T);
            if (!t.IsEnum) { throw new ApplicationException("Tipo debe de ser Enum"); }

            var members = t.GetFields(BindingFlags.Public | BindingFlags.Static);

            var result = new List<SelectListItem>();

            foreach (var member in members)
            {
                var attributeDescription = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                var descripcion = member.Name;

                if (attributeDescription.Any())
                {
                    descripcion = ((System.ComponentModel.DescriptionAttribute)attributeDescription[0]).Description;
                }

                var valor = ((int)Enum.Parse(t, member.Name));
                result.Add(new SelectListItem()
                {
                    Text = descripcion,
                    Value = valor.ToString()
                });

            }
            return result;
        }

        [HttpGet]
        public ActionResult FormularioRazorBeginForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormularioRazorBeginForm(peliculas pelicula)
        {
            ViewBag.Message = "Exitoso!!!, Paso por el Formulario";
            return View(pelicula);
        }

        public ActionResult VistasParciales()
        {
            ViewBag.ListaProductos = producto.Listar();
            return View();
        }
    }
}

