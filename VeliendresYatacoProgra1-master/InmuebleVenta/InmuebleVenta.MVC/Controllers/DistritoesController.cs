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
    public class DistritoesController : Controller
    {

        private readonly IUnityOfWork _UnityOfWork;

        public DistritoesController()
        {

        }

        public DistritoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Distritoes
        public ActionResult Index()
        {
            //return View(db.Distritos.ToList());
            return View(_UnityOfWork.Distrito.GetAll());
        }

        // GET: Distritoes/Details/5
        public ActionResult Details(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  Distrito distrito = db.Distritos.Find(id);
            Distrito distrito = _UnityOfWork.Distrito.Get(id);


            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distritoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distritoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistritoId,Nombre")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
               //  db.Distritos.Add(distrito);
                _UnityOfWork.Distrito.Add(distrito);
                // db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distrito);
        }

        // GET: Distritoes/Edit/5
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistritoId,Nombre")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(distrito).State = EntityState.Modified;
                _UnityOfWork.StateModified(distrito);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distrito);
        }

        // GET: Distritoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Distrito distrito = db.Distritos.Find(id);
            Distrito distrito = _UnityOfWork.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = _UnityOfWork.Distrito.Get(id);

            // db.Distritos.Remove(distrito);
            _UnityOfWork.Distrito.Delete(distrito);
            // db.SaveChanges();
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
