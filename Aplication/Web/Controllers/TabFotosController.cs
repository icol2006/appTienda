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
        public ActionResult Create(String CodPro)
        {            
            ViewBag.Codigo = new SelectList(new ProductoRepository().GetList(null, null), "CodPro", "CodPro", CodPro);
           
            return View();
        }

        // POST: TabFotos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tipo,Codigo,item,titulo,descripcion,foto")] TabFotos tabFotos)
        {
            ViewBag.Observacion = "";

            if (ModelState.IsValid)
            {
                var datos=tabFotosRepository.GetOne(x=>x.Codigo.Equals(tabFotos.Codigo) 
                && x.item==tabFotos.item 
                && x.Tipo.Equals(tabFotos.Tipo)
                ,null);

                if (datos == null)
                {
                    tabFotosRepository.Insert(tabFotos);
                    return RedirectToAction("Edit", "Productos", new { id = tabFotos.Codigo.Trim() });
                }
                else
                {
                    ViewBag.Observacion = "La foto ya existe en el registro del producto";
                }

            }

            ViewBag.Codigo = new SelectList(new ProductoRepository().GetList(null, null), "CodPro", "CodPro", tabFotos.Codigo);
            return View(tabFotos);
        }

        // GET: TabFotos/Edit/5
        public ActionResult Edit(string tipo, string codigo,int item)
        {
            if (tipo == null || codigo==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabFotos tabFotos = tabFotosRepository.GetOne(x=>x.Tipo.Equals(tipo) 
            && x.Codigo.Equals(codigo) 
            && x.item==item,null);

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
            }

            return RedirectToAction("Edit", "Productos", new { id = tabFotos.Codigo.Trim() });
        }

        // GET: DomClis/Delete/5
        public ActionResult Delete(string tipo, string codigo, int item)
        {
            var tabFotos = tabFotosRepository.GetOne(x => x.Tipo.Equals(tipo) &&
                     x.Codigo.Equals(codigo) && x.item==item, null);

            tabFotosRepository.Delete(tabFotos);

            return RedirectToAction("Edit", "Productos", new { id = tabFotos.Codigo.Trim() });
        }
        
    }
}
