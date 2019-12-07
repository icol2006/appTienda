using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;

namespace Web.Controllers
{
    [Authorize]
    public class KardexProductosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: KardexProductos
        public ActionResult Index()
        {
            var kardexProductos = db.KardexProductos.Include(k => k.Almacen).Include(k => k.Producto);
            return View(kardexProductos.ToList());
        }

        // GET: KardexProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KardexProductos kardexProductos = db.KardexProductos.Find(id);
            if (kardexProductos == null)
            {
                return HttpNotFound();
            }
            return View(kardexProductos);
        }

        // GET: KardexProductos/Create
        public ActionResult Create()
        {
            ViewBag.CodAlm = new SelectList(db.Almacen, "CodAlm", "DesAlm");
            ViewBag.CodPro = new SelectList(db.Producto, "CodPro", "CodLin");
            return View();
        }

        // POST: KardexProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnoProc,IdKardex,Fecha,CodPro,CodAlm,TipoOperacion,StokIni,cantidad,StokFin,IdOperacion,ModuloOperacion,FechaCreacion")] KardexProductos kardexProductos)
        {
            if (ModelState.IsValid)
            {
                db.KardexProductos.Add(kardexProductos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodAlm = new SelectList(db.Almacen, "CodAlm", "DesAlm", kardexProductos.CodAlm);
            ViewBag.CodPro = new SelectList(db.Producto, "CodPro", "CodLin", kardexProductos.CodPro);
            return View(kardexProductos);
        }

        // GET: KardexProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KardexProductos kardexProductos = db.KardexProductos.Find(id);
            if (kardexProductos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAlm = new SelectList(db.Almacen, "CodAlm", "DesAlm", kardexProductos.CodAlm);
            ViewBag.CodPro = new SelectList(db.Producto, "CodPro", "CodLin", kardexProductos.CodPro);
            return View(kardexProductos);
        }

        // POST: KardexProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnoProc,IdKardex,Fecha,CodPro,CodAlm,TipoOperacion,StokIni,cantidad,StokFin,IdOperacion,ModuloOperacion,FechaCreacion")] KardexProductos kardexProductos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kardexProductos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodAlm = new SelectList(db.Almacen, "CodAlm", "DesAlm", kardexProductos.CodAlm);
            ViewBag.CodPro = new SelectList(db.Producto, "CodPro", "CodLin", kardexProductos.CodPro);
            return View(kardexProductos);
        }

        // GET: KardexProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KardexProductos kardexProductos = db.KardexProductos.Find(id);
            if (kardexProductos == null)
            {
                return HttpNotFound();
            }
            return View(kardexProductos);
        }

        // POST: KardexProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KardexProductos kardexProductos = db.KardexProductos.Find(id);
            db.KardexProductos.Remove(kardexProductos);
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
