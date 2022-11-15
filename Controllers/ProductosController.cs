using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DS_System.Models;

namespace DS_System.Controllers
{
    public class ProductosController : Controller
    {
        private puntoDeventaEntities db = new puntoDeventaEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Clasificacion).Include(p => p.Proveedores);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.IdClasificacion = new SelectList(db.Clasificacion, "IdClasificacion", "Descripcion");
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "NombreContacto");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CDBarras,IdProveedor,NommbreProduc,Descripcion,Stock,PrecioCom,PrecioVen,Caducidad,FechaRegis,IdClasificacion")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClasificacion = new SelectList(db.Clasificacion, "IdClasificacion", "Descripcion", productos.IdClasificacion);
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "NombreContacto", productos.IdProveedor);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClasificacion = new SelectList(db.Clasificacion, "IdClasificacion", "Descripcion", productos.IdClasificacion);
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "NombreContacto", productos.IdProveedor);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CDBarras,IdProveedor,NommbreProduc,Descripcion,Stock,PrecioCom,PrecioVen,Caducidad,FechaRegis,IdClasificacion")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClasificacion = new SelectList(db.Clasificacion, "IdClasificacion", "Descripcion", productos.IdClasificacion);
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "NombreContacto", productos.IdProveedor);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
