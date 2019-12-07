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
    public class ClientesController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(clienteRepository.GetList(null, null));
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodCli,nomcli,tipdoc,numdoc,estado,telefono,correo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Insert(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            var asd = Request;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = clienteRepository.GetOne((x => x.CodCli.Equals(id)),
                new string[] { typeof(DomCli).Name });

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodCli,nomcli,tipdoc,numdoc,estado,telefono,correo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

    }
}
