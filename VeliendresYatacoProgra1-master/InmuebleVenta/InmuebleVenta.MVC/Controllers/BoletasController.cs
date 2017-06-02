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
    public class BoletasController : Controller
    {
        //private InmuebleVentaDbContext db = new InmuebleVentaDbContext();
        private readonly UnityOfWork unityOfWork = UnityOfWork.Instance;
        // GET: Boletas

        

        public ActionResult Index()
        {
            // return View(db.Comprobantes.ToList());
            return View(unityOfWork.Boleta.GetAll());
        }

        // GET: Boletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Boleta boleta = db.Comprobantes.Find(id);
            Boleta boleta = unityOfWork.Boleta.Get(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // GET: Boletas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComprobanteId,Fecha,Monto,ContratoResarvaId,ContratoAlquilerId")] Boleta boleta)
        {
            if (ModelState.IsValid)
            {
                //db.Comprobantes.Add(boleta);
                unityOfWork.Boleta.Add(boleta);

                // db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boleta);
        }

        // GET: Boletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Boleta boleta = db.Comprobantes.Find(id);
            Boleta boleta = unityOfWork.Boleta.Get(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // POST: Boletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComprobanteId,Fecha,Monto,ContratoResarvaId,ContratoAlquilerId")] Boleta boleta)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(boleta).State = EntityState.Modified;
                unityOfWork.StateModified(boleta);
                // db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boleta);
        }

        // GET: Boletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Boleta boleta = db.Comprobantes.Find(id);
            Boleta boleta = unityOfWork.Boleta.Get(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // POST: Boletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Boleta boleta = db.Comprobantes.Find(id);
            Boleta boleta = unityOfWork.Boleta.Get(id);

            //db.Comprobantes.Remove(boleta);
            unityOfWork.Boleta.Delete(boleta);

            // db.SaveChanges();
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
