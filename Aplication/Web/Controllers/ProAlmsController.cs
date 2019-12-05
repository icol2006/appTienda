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
    public class ProAlmsController : Controller
    {
        ProAlmRepository proAlmRepository = new ProAlmRepository();

        // GET: ProAlms
        public ActionResult Index()
        {
            var proAlm = proAlmRepository.GetList(null,null);
            return View(proAlm.ToList());
        }

        public ActionResult ListarProductosAlmacen(String codAlm)
        {
            ViewBag.Almacen = new AlmacenRepository().GetOne(x => x.CodAlm.Equals(codAlm), null).CodAlm;

            var proAlm = proAlmRepository.GetList(x => x.CodAlm.Equals(codAlm), 
                new string[] { typeof(Producto).Name,typeof(Almacen).Name });
            return View(proAlm.ToList());
        }

        // GET: ProAlms/Create
        public ActionResult Create(String codAlm)
        {          
            ViewBag.CodAlm = new SelectList(new AlmacenRepository().GetList(null,null),"CodAlm", "DesAlm", codAlm);
            ViewBag.CodPro = new SelectList(new ProductoRepository().GetList(null,null),"CodPro", "NomPro");
            return View();
        }

        // POST: ProAlms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodAlm,CodPro,Stock")] ProAlm proAlm)
        {
            ViewBag.Observacion = "";

            var datos= proAlmRepository.GetOne(x => x.CodAlm.Equals(proAlm.CodAlm) && x.CodPro.Equals(proAlm.CodPro),null);

            if (ModelState.IsValid)
            {
                if(datos==null)
                {
                    proAlmRepository.Insert(proAlm);
                    return RedirectToAction("ListarProductosAlmacen", "ProAlms", new { codAlm = proAlm.CodAlm.Trim() });
                }
                else
                {
                    ViewBag.Observacion = "El producto ya existe en el inventario";
                }

            }
            ViewBag.CodAlm = new SelectList(new AlmacenRepository().GetList(null, null),"CodAlm", "DesAlm", proAlm.CodAlm);
            ViewBag.CodPro = new SelectList(new ProductoRepository().GetList(null, null),"CodPro", "CodLin", proAlm.CodPro);

            return View(proAlm);
        }

        // GET: ProAlms/Edit/5
        public ActionResult Edit(string codAlm,string codPro)
        {
            if (codAlm == null || codPro==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProAlm proAlm = proAlmRepository.GetOne(x => x.CodAlm.Equals(codAlm)
            && x.CodPro.Equals(codPro),new string[] {typeof(Producto).Name,typeof(Almacen).Name });

            if (proAlm == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodAlm = new SelectList(new AlmacenRepository().GetList(null, null),"CodAlm", "DesAlm", proAlm.CodAlm);
            ViewBag.CodPro = new SelectList(new ProductoRepository().GetList(null, null),"CodPro", "CodLin", proAlm.CodPro);

            return View(proAlm);
        }

        // POST: ProAlms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodAlm,CodPro,Stock")] ProAlm proAlm)
        {
            if (ModelState.IsValid)
            {
                proAlmRepository.Update(proAlm);
                return RedirectToAction("ListarProductosAlmacen", "ProAlms", new { codAlm = proAlm.CodAlm.Trim() });
            }
            ViewBag.CodAlm = new SelectList(new AlmacenRepository().GetList(null, null),"CodAlm", "DesAlm", proAlm.CodAlm);
            ViewBag.CodPro = new SelectList(new ProductoRepository().GetList(null, null),"CodPro", "CodLin", proAlm.CodPro);
            return View(proAlm);
        }

    }
}
