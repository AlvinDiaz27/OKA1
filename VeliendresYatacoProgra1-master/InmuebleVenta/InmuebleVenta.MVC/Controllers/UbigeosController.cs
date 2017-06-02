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
    public class UbigeosController : Controller
    {
        //private InmuebleVentaDbContext db = new InmuebleVentaDbContext();
        private readonly UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: Ubigeos
        public ActionResult Index()
        {
            //var ubigeos = db.Ubigeos.Include(u => u.Departamento).Include(u => u.Distrito).Include(u => u.Provincia);
            return View(unityOfWork.Ubigeo.GetAll());
        }

        // GET: Ubigeos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = unityOfWork.Ubigeo.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // GET: Ubigeos/Create
        public ActionResult Create()
        {
            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre");
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre");
            //ViewBag.ProvinciaId = new SelectList(db.Provinciass, "ProvinciaId", "Nombre");
            return View();
        }

        // POST: Ubigeos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UbigeoId,DepartamentoId,ProvinciaId,DistritoId")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                //db.Ubigeos.Add(ubigeo);
                unityOfWork.Ubigeo.Add(ubigeo);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", ubigeo.DepartamentoId);
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre", ubigeo.DistritoId);
            //ViewBag.ProvinciaId = new SelectList(db.Provinciass, "ProvinciaId", "Nombre", ubigeo.ProvinciaId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = unityOfWork.Ubigeo.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", ubigeo.DepartamentoId);
            //ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre", ubigeo.DistritoId);
            //ViewBag.ProvinciaId = new SelectList(db.Provinciass, "ProvinciaId", "Nombre", ubigeo.ProvinciaId);
            return View(ubigeo);
        }

        // POST: Ubigeos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UbigeoId,DepartamentoId,ProvinciaId,DistritoId")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ubigeo).State = EntityState.Modified;
                unityOfWork.StateModified(ubigeo);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "Nombre", ubigeo.DepartamentoId);
           // ViewBag.DistritoId = new SelectList(db.Distritos, "DistritoId", "Nombre", ubigeo.DistritoId);
           // ViewBag.ProvinciaId = new SelectList(db.Provinciass, "ProvinciaId", "Nombre", ubigeo.ProvinciaId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = unityOfWork.Ubigeo.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // POST: Ubigeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Ubigeo ubigeo = db.Ubigeos.Find(id);
            Ubigeo ubigeo = unityOfWork.Ubigeo.Get(id);
            //db.Ubigeos.Remove(ubigeo);
            unityOfWork.Ubigeo.Delete(ubigeo);
            //db.SaveChanges();
            unityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
