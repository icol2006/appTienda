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
    public class LineaProductosController : Controller
    {
        LineaProductoRepository lineaProductoRepository = new LineaProductoRepository();

        // GET: LineaProductos
        public ActionResult Index()
        {
            return View(lineaProductoRepository.GetList(null,null));
        }

        // GET: LineaProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodLin,DesLin,Estado")] LineaProducto lineaProducto)
        {
            if (ModelState.IsValid)
            {
                lineaProductoRepository.Insert(lineaProducto);
                return RedirectToAction("Index");
            }

            return View(lineaProducto);
        }

        // GET: LineaProductos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lineaProducto = lineaProductoRepository.GetOne(x => x.CodLin.Equals(id),
                new string[] { typeof(SubLineaProducto).Name });
            if (lineaProducto == null)
            {
                return HttpNotFound();
            }
            return View(lineaProducto);
        }

        // POST: LineaProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodLin,DesLin,Estado")] LineaProducto lineaProducto)
        {
            if (ModelState.IsValid)
            {
                lineaProductoRepository.Update(lineaProducto);
                return RedirectToAction("Index");
            }
            return View(lineaProducto);
        }

    }
}
