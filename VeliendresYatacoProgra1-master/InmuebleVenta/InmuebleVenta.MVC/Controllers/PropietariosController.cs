using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InmuebleVenta.Entities;
using InmuebleVenta.Persistence;
using InmuebleVenta.Persistence.Repositories;

namespace InmuebleVenta.MVC.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Propietarios
        public ActionResult Index()
        {
            //var propietarios = db.Propietarios.Include(p => p.Contrato);
            return View(unityOfWork.Propietario.GetAll());
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = unityOfWork.Propietario.Get(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // GET: Propietarios/Create
        public ActionResult Create()
        {
            //ViewBag.PropietarioDNI = new SelectList(db.Contratos, "ContratoId", "NombreCliente");
            return View();
        }

        // POST: Propietarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropietarioDNI,NombrePropietario,ApePropietario,TelefonoPropietario,DireccionPropietario,InmuebleId,ContratoId")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.Propietario.Add(propietario);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.PropietarioDNI = new SelectList(db.Contratos, "ContratoId", "NombreCliente", propietario.PropietarioDNI);
            return View(propietario);
        }

        // GET: Propietarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = unityOfWork.Propietario.Get(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
           // ViewBag.PropietarioDNI = new SelectList(db.Contratos, "ContratoId", "NombreCliente", propietario.PropietarioDNI);
            return View(propietario);
        }

        // POST: Propietarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropietarioDNI,NombrePropietario,ApePropietario,TelefonoPropietario,DireccionPropietario,InmuebleId,ContratoId")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.StateModified(propietario);
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.PropietarioDNI = new SelectList(db.Contratos, "ContratoId", "NombreCliente", propietario.PropietarioDNI);
            return View(propietario);
        }

        // GET: Propietarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = unityOfWork.Propietario.Get(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propietario propietario = unityOfWork.Propietario.Get(id);
            unityOfWork.Propietario.Delete(propietario);
            unityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
