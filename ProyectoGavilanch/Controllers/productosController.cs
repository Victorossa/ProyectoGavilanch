using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModeloDatos.Datos;

namespace ProyectoGavilanch.Controllers
{
    public class productosController : Controller
    {
        private BD_ProyectoGavilanchContext db = new BD_ProyectoGavilanchContext();

        // GET: productos
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.gruposProductos).Include(p => p.marcas);
            return View(productos.ToList());
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: productos/Create
        public ActionResult Create()
        {
            ViewBag.GrupoProducto_Id = new SelectList(db.gruposProductos, "GrupoProducto_Id", "Nombre_Grupo");
            ViewBag.Marca_Id = new SelectList(db.marcas, "Marca_Id", "NombreMarca");
            return View();
        }

        // POST: productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Producto_Id,Nombre,Descripcion,Imagen,Precio,GrupoProducto_Id,Marca_Id")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoProducto_Id = new SelectList(db.gruposProductos, "GrupoProducto_Id", "Nombre_Grupo", productos.GrupoProducto_Id);
            ViewBag.Marca_Id = new SelectList(db.marcas, "Marca_Id", "NombreMarca", productos.Marca_Id);
            return View(productos);
        }

        // GET: productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoProducto_Id = new SelectList(db.gruposProductos, "GrupoProducto_Id", "Nombre_Grupo", productos.GrupoProducto_Id);
            ViewBag.Marca_Id = new SelectList(db.marcas, "Marca_Id", "NombreMarca", productos.Marca_Id);
            return View(productos);
        }

        // POST: productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Producto_Id,Nombre,Descripcion,Imagen,Precio,GrupoProducto_Id,Marca_Id")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoProducto_Id = new SelectList(db.gruposProductos, "GrupoProducto_Id", "Nombre_Grupo", productos.GrupoProducto_Id);
            ViewBag.Marca_Id = new SelectList(db.marcas, "Marca_Id", "NombreMarca", productos.Marca_Id);
            return View(productos);
        }

        // GET: productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos productos = db.productos.Find(id);
            db.productos.Remove(productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
