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
    [Authorize]
    public class SubLineaProductosController : Controller
    {
        SubLineaProductoRepository subLineaProductoRepository = new SubLineaProductoRepository();

        // GET: SubLineaProductos
        public ActionResult Index()
        {
            var subLineaProducto = subLineaProductoRepository.GetList(null,
                new string[] { typeof(LineaProducto).Name });
            return View(subLineaProducto.ToList());
        }

        // GET: SubLineaProductos/Create
        public ActionResult Create()
        {
            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null,null), 
                "CodLin", "DesLin");
            return View();
        }

        // POST: SubLineaProductos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodSubLin,CodLin,DesLin,Estado")] SubLineaProducto subLineaProducto)
        {

            if (ModelState.IsValid)
            {
                subLineaProductoRepository.Insert(subLineaProducto);

                return RedirectToAction("Index");
            }

            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null, null), 
                "CodLin", "DesLin", subLineaProducto.CodLin);
            return View(subLineaProducto);
        }

        // GET: SubLineaProductos/Edit/5
        public ActionResult Edit(string id)
        {
            @ViewBag.resultado = TempData["resultado"];
            TempData["resultado"] = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubLineaProducto subLineaProducto = subLineaProductoRepository.GetOne(x=>x.CodSubLin.Equals(id),null);
            if (subLineaProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null, null),
                "CodLin", "DesLin", subLineaProducto.CodLin);
            return View(subLineaProducto);
        }

        // POST: SubLineaProductos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodSubLin,CodLin,DesLin,Estado")] SubLineaProducto subLineaProducto)
        {
            if (ModelState.IsValid)
            {
                subLineaProductoRepository.Update(subLineaProducto);
                TempData["resultado"] = "Grabacion satisfactoria";

                return RedirectToAction("Edit");
            }
            ViewBag.CodLin = new SelectList(new LineaProductoRepository().GetList(null, null), 
                "CodLin", "DesLin", subLineaProducto.CodLin);
            return View(subLineaProducto);
        }
    }
}
