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
    public class DomClisController : Controller
    {
        private DomCliRepository domCliRepository = new DomCliRepository();

        // GET: DomClis
        public ActionResult Index() 
        {
            return View(domCliRepository.GetList(null,new String[] {"Cliente" }));
        }


        // GET: DomClis/Create
        public ActionResult Create(String CodCli)
        {
            ViewBag.CodCli = new SelectList(new ClienteRepository().GetList(null,null), "CodCli", "CodCli", CodCli);
            ViewBag.CodigoCliente = CodCli;

            return View();
        }

        // POST: DomClis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCli,CodDom,direccion,estado,telefono,correo")] DomCli domCli)
        {
            ViewBag.Observacion = "";

            var datos = domCliRepository.GetOne(x => x.CodDom.Equals(domCli.CodDom) 
            && x.CodCli.Equals(domCli.CodCli), null);

            if (ModelState.IsValid)
            {
                if(datos==null)
                {
                    domCliRepository.Insert(domCli);

                    return RedirectToAction("Edit", "Clientes", new { id = domCli.CodCli.Trim() });
                }
                else
                {
                    ViewBag.Observacion = "Ya existe un registro con el mismo item y tipo";
                }

            }

            ViewBag.CodCli = new SelectList(domCliRepository.GetList(null, new String[] { "Cliente" }), "CodCli", "nomcli", domCli.CodCli);
            return View(domCli);
        }

        // GET: DomClis/Edit/5
        public ActionResult Edit(string codDom, string codCli)
        {
            @ViewBag.resultado = TempData["resultado"];
            TempData["resultado"] = null;

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
                TempData["resultado"] = "Grabacion satisfactoria";

            }
        //    @Html.ActionLink("Editar", "Edit", "DomClis", new { CodCli = domCli.CodCli.Trim(), CodDom = domCli.CodDom.Trim() }, new { @class = "label label-sm label-success" })

            return RedirectToAction("Edit","DomClis", new { CodCli = domCli.CodCli.Trim(), CodDom = domCli.CodDom.Trim() });
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
