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
    public class DomClisController : Controller
    {
        private DomCliRepository domCliRepository = new DomCliRepository();

        // GET: DomClis
        public ActionResult Index() 
        {
            return View(domCliRepository.GetList(null,new String[] {"Cliente" }));
        }

        // GET: DomClis/Details/5
        public ActionResult Details(string codDom, string codCli)
        {
            if (codDom == null && codCli == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var domCli = domCliRepository.GetOne(x => x.CodDom.Equals(codDom) &&
             x.CodCli.Equals(codCli), new String[] { "Cliente" });

            if (domCli == null)
            {
                return HttpNotFound();
            }
            return View(domCli);
        }

        // GET: DomClis/Create
        public ActionResult Create()
        {
            ViewBag.CodCli = new SelectList(domCliRepository.GetList(null, new String[] { "Cliente" }), "CodCli", "nomcli");
            return View();
        }

        // POST: DomClis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCli,CodDom,direccion,estado,telefono,correo")] DomCli domCli)
        {
            if (ModelState.IsValid)
            {
                domCliRepository.Insert(domCli);
                return RedirectToAction("Index");
            }

            ViewBag.CodCli = new SelectList(domCliRepository.GetList(null, new String[] { "Cliente" }), "CodCli", "nomcli", domCli.CodCli);
            return View(domCli);
        }

        // GET: DomClis/Edit/5
        public ActionResult Edit(string codDom, string codCli)
        {
            if (codDom == null && codCli == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             var  domCli=domCliRepository.GetOne(x => x.CodDom.Equals(codDom) && 
                        x.CodCli.Equals(codCli), new String[] { "Cliente" });

            if (domCli == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCli = new SelectList(domCliRepository.GetList(null,null), "CodCli", "nomcli", domCli.CodCli);
            return View(domCli);
        }

        // POST: DomClis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCli,CodDom,direccion,estado,telefono,correo")] DomCli domCli)
        {
            if (ModelState.IsValid)
            {
                domCliRepository.Update(domCli);
     
            }
            return RedirectToAction("Edit", "Clientes", new { id = domCli.CodCli.Trim() });
        }

        // GET: DomClis/Delete/5
        public ActionResult Delete(string codDom, string codCli)
        {
            var domCli = domCliRepository.GetOne(x => x.CodDom.Equals(codDom) &&
                     x.CodCli.Equals(codCli), null);

            domCliRepository.Delete(domCli);

            return RedirectToAction("Edit","Clientes", new { id = codCli.Trim() });
        }

        // POST: DomClis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string codDom, string codCli)
        {
            var domCli = domCliRepository.GetOne(x => x.CodDom.Equals(codDom) &&
                     x.CodCli.Equals(codCli), null);

            domCliRepository.Delete(domCli);

            return RedirectToAction("Index");
        }

    }
}
