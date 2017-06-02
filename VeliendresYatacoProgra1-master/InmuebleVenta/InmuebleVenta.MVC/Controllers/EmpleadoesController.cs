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
    public class EmpleadoesController : Controller
    {
        //private InmuebleVentaDbContext db = new InmuebleVentaDbContext();
        private readonly UnityOfWork unityOfWork = UnityOfWork.Instance;
        // GET: Empleadoes
        public ActionResult Index()
        {
            return View(unityOfWork.Empleado.GetAll());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = unityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoDNI,NombreEmpleado,ApeEmpleado,TelefonoEmpleado,DireccionEmpleado,VisitaId,ContratoId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                //db.Empleados.Add(empleado);
                unityOfWork.Empleado.Add(empleado);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = unityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoDNI,NombreEmpleado,ApeEmpleado,TelefonoEmpleado,DireccionEmpleado,VisitaId,ContratoId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(empleado).State = EntityState.Modified;
                unityOfWork.StateModified(empleado);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = unityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = unityOfWork.Empleado.Get(id);
            //db.Empleados.Remove(empleado);
            unityOfWork.Empleado.Delete(empleado);
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
