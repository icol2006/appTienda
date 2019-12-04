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
    public class ProveedoresController : Controller
    {
        ProveedorRepository proveedorRepository = new ProveedorRepository();
        // GET: Proveedores
        public ActionResult Index()
        {
            return View(proveedorRepository.GetList(null,null));
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPrv,NomPrv,estado,tipdoc,numdoc,correo")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                proveedorRepository.Insert(proveedor);
                return RedirectToAction("Index");
            }

            return View(proveedor);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = proveedorRepository.GetOne(x=>x.CodPrv.Equals(id),null);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPrv,NomPrv,estado,tipdoc,numdoc,correo")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                proveedorRepository.Update(proveedor);
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }


    }
}
