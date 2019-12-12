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
    public class AlmacenesController : Controller
    {
        AlmacenRepository almacenRepository = new AlmacenRepository();

        // GET: Almacenes
        public ActionResult Index()
        {
            return View(almacenRepository.GetList(null,null));
        }

        // GET: Almacenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Almacenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodAlm,DesAlm,estado")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {               
                almacenRepository.Insert(almacen);

                return RedirectToAction("Index");
            }

            return View(almacen);
        }

        // GET: Almacenes/Edit/5
        public ActionResult Edit(string id)
        {
            @ViewBag.resultado = TempData["resultado"];
            TempData["resultado"] = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacen almacen = almacenRepository.GetOne(x => x.CodAlm.Equals(id), null);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: Almacenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodAlm,DesAlm,estado")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                almacenRepository.Update(almacen);
                TempData["resultado"] = "Grabacion satisfactoria";

                return RedirectToAction("Edit");
            }
            return View(almacen);
        }

    }
}
