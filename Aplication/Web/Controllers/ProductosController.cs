using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Data;
using DAL.Models;

namespace Web.Controllers
{
    public class ProductosController : Controller
    {
        ProductoRepository productoRepository = new ProductoRepository();
        // GET: Productos
        public ActionResult Index()
        {
            var producto = productoRepository.GetList(null,
                new string[] { typeof(LineaProducto).Name,
                    typeof(SubLineaProducto).Name, typeof(UnidadMedida).Name });

            return View(producto.ToList());
        }


        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null,null),
                "CodLin", "DesLin");
            ViewBag.CodSubLin = new SelectList(new SubLineaProductoRepository().GetList(null,null),
                "CodSubLin", "DesLin");
            ViewBag.CodUniMed = new SelectList(new UnidadMedidaRepository().GetList(null,null), 
                "CodUnidadMed", "DesUniMed");
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPro,CodLin,CodSubLin,NomPro,estado,CodUniMed,precio,afectoigv,TipPro")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                productoRepository.Insert(producto);
                return RedirectToAction("Index");
            }

            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null, null), 
                "CodLin", "DesLin", producto.CodLin);
            ViewBag.CodSubLin = new SelectList(new SubLineaProductoRepository().GetList(null, null),
                "CodSubLin", "DesLin", producto.CodSubLin);
            ViewBag.CodUniMed = new SelectList(new UnidadMedidaRepository().GetList(null, null),
                "CodUnidadMed", "DesUniMed", producto.CodUniMed);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = productoRepository.GetOne(x => x.CodPro.Equals(id),
                new string[] {typeof(TabFotos).Name });

            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null, null), 
                "CodLin", "DesLin", producto.CodLin);
            ViewBag.CodSubLin = new SelectList(new SubLineaProductoRepository().GetList(null, null),
                "CodSubLin", "DesLin", producto.CodSubLin);
            ViewBag.CodUniMed = new SelectList(new UnidadMedidaRepository().GetList(null, null), 
                "CodUnidadMed", "DesUniMed", producto.CodUniMed);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPro,CodLin,CodSubLin,NomPro,estado,CodUniMed,precio,afectoigv,TipPro")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                productoRepository.Update(producto);
                return RedirectToAction("Index");
            }
            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null, null),
                "CodLin", "DesLin", producto.CodLin);
            ViewBag.CodSubLin = new SelectList(new SubLineaProductoRepository().GetList(null, null),
                "CodSubLin", "CodLin", producto.CodSubLin);
            ViewBag.CodUniMed = new SelectList(new UnidadMedidaRepository().GetList(null, null),
                "CodUnidadMed", "DesUniMed", producto.CodUniMed);
            return View(producto);
        }

    }
}
