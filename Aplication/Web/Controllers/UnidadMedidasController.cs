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
    public class UnidadMedidasController : Controller
    {     
        UnidadMedidaRepository unidadMedidaRepository = new UnidadMedidaRepository();
        // GET: UnidadMedidas
        public ActionResult Index()
        {
            return View(unidadMedidaRepository.GetList(null,null));
        }

        // GET: UnidadMedidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadMedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodUnidadMed,DesUniMed,Estado")] UnidadMedida unidadMedida)
        {
            if (ModelState.IsValid)
            {
                unidadMedidaRepository.Insert(unidadMedida);
                return RedirectToAction("Index");
            }

            return View(unidadMedida);
        }

        // GET: UnidadMedidas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadMedida unidadMedida = unidadMedidaRepository.GetOne(x=>x.CodUnidadMed.Equals(id),null);
            if (unidadMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadMedida);
        }

        // POST: UnidadMedidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodUnidadMed,DesUniMed,Estado")] UnidadMedida unidadMedida)
        {
            if (ModelState.IsValid)
            {
                unidadMedidaRepository.Update(unidadMedida);
                return RedirectToAction("Index");
            }
            return View(unidadMedida);
        }

    }
}
