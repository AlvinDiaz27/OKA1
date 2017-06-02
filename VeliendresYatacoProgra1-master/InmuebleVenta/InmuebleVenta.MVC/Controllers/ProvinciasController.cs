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
using InmuebleVenta.Entities.IRepositories;

namespace InmuebleVenta.MVC.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public ProvinciasController()
        {

        }

        public ProvinciasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Provincias
        public ActionResult Index()
        {
            //return View(db.Provinciass.ToList());
            return View(_UnityOfWork.Provincia.GetAll());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Provincia provincia = db.Provinciass.Find(id);
            Provincia provincia = _UnityOfWork.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provincias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaId,Nombre")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                // db.Provinciass.Add(provincia);
                _UnityOfWork.Provincia.Add(provincia);

                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaId,Nombre")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(provincia).State = EntityState.Modified;
                _UnityOfWork.StateModified(provincia);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Provincia provincia = db.Provinciass.Find(id);
            Provincia provincia = _UnityOfWork.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Provincia provincia = db.Provinciass.Find(id);
            Provincia provincia = _UnityOfWork.Provincia.Get(id);

            //db.Provinciass.Remove(provincia);
            _UnityOfWork.Provincia.Delete(provincia);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
