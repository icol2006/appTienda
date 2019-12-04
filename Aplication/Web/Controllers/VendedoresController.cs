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
    public class VendedoresController : Controller
    {
        VendedorRepository vendedorRepository = new VendedorRepository();

        // GET: Vendedores
        public ActionResult Index()
        {
            return View(vendedorRepository.GetList(null,null));
        }

        // GET: Vendedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendedores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodVnd,nomvnd,tipdoc,numdoc,estado,telefono,correo")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                vendedorRepository.Insert(vendedor);
                return RedirectToAction("Index");
            }

            return View(vendedor);
        }

        // GET: Vendedores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = vendedorRepository.GetOne(x=>x.CodVnd.Equals(id),null);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodVnd,nomvnd,tipdoc,numdoc,estado,telefono,correo")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                vendedorRepository.Update(vendedor);
                return RedirectToAction("Index");
            }
            return View(vendedor);
        }

    }
}
