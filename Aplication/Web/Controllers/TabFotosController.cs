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
    public class TabFotosController : Controller
    {
        TabFotosRepository tabFotosRepository = new TabFotosRepository();

        // GET: TabFotos
        public ActionResult Index()
        {
            var tabFotos =tabFotosRepository.GetList(null,new string[] {typeof(Producto).Name });
            return View(tabFotos.ToList());
        }


        // GET: TabFotos/Create
        public ActionResult Create()
        {
            ViewBag.Codigo = new SelectList(new ProductoRepository().GetList(null,null), "CodPro", "CodLin");
            return View();
        }

        // POST: TabFotos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tipo,Codigo,item,titulo,descripcion,foto")] TabFotos tabFotos)
        {
            if (ModelState.IsValid)
            {
                tabFotosRepository.Insert(tabFotos);
                return RedirectToAction("Index");
            }

            ViewBag.Codigo = new SelectList(new ProductoRepository().GetList(null, null), "CodPro", "CodLin", tabFotos.Codigo);
            return View(tabFotos);
        }

        // GET: TabFotos/Edit/5
        public ActionResult Edit(string tipo, string codigo,string item)
        {
            if (tipo == null || codigo==null || item ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabFotos tabFotos = tabFotosRepository.GetOne(x=>x.Tipo.Equals(tipo) 
            && x.Codigo.Equals(codigo) 
            && x.item.Equals(item),null);

            if (tabFotos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo = new SelectList(new ProductoRepository().GetList(null, null), 
                "CodPro", "CodLin", tabFotos.Codigo);
            return View(tabFotos);
        }

        // POST: TabFotos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tipo,Codigo,item,titulo,descripcion,foto")] TabFotos tabFotos)
        {
            if (ModelState.IsValid)
            {
                tabFotosRepository.Update(tabFotos);
                return RedirectToAction("Index");
            }
            ViewBag.Codigo = new SelectList(new ProductoRepository().GetList(null, null),
                "CodPro", "CodLin", tabFotos.Codigo);
            return View(tabFotos);
        }

    }
}
