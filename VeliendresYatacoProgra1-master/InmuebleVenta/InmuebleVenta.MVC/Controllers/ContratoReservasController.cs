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
    public class ContratoReservasController : Controller
    {
        private readonly UnityOfWork unityOfWork = UnityOfWork.Instance;

        // GET: ContratoReservas
        public ActionResult Index()
        {
            //var contratos = db.Contratos.Include(c => c.Cliente).Include(c => c.Empleado);
            return View(unityOfWork.ContratoReserva.GetAll());
        }

        // GET: ContratoReservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoReserva contratoReserva = unityOfWork.ContratoReserva.Get(id);
            if (contratoReserva == null)
            {
                return HttpNotFound();
            }
            return View(contratoReserva);
        }

        // GET: ContratoReservas/Create
        public ActionResult Create()
        {
            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente");
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado");
            return View();
        }

        // POST: ContratoReservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,Fecha,ClienteDNI,NombreCliente,ApeCliente,PropietarioDNI,ApePropietario,NombrePropietario,InmuebleId,PrecioInmueble,EmpleadoDNI,NombreEmpleado,ApeEmpleado,MontoCuotas")] ContratoReserva contratoReserva)
        {
            if (ModelState.IsValid)
            {
                //db.Contratos.Add(contratoReserva);
                unityOfWork.ContratoReserva.Add(contratoReserva);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoReserva.ClienteDNI);
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoReserva.EmpleadoDNI);
            return View(contratoReserva);
        }

        // GET: ContratoReservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoReserva contratoReserva = unityOfWork.ContratoReserva.Get(id);
            if (contratoReserva == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoReserva.ClienteDNI);
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoReserva.EmpleadoDNI);
            return View(contratoReserva);
        }

        // POST: ContratoReservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,Fecha,ClienteDNI,NombreCliente,ApeCliente,PropietarioDNI,ApePropietario,NombrePropietario,InmuebleId,PrecioInmueble,EmpleadoDNI,NombreEmpleado,ApeEmpleado,MontoCuotas")] ContratoReserva contratoReserva)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contratoReserva).State = EntityState.Modified;
                unityOfWork.StateModified(contratoReserva);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoReserva.ClienteDNI);
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoReserva.EmpleadoDNI);
            return View(contratoReserva);
        }

        // GET: ContratoReservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoReserva contratoReserva = unityOfWork.ContratoReserva.Get(id);
            if (contratoReserva == null)
            {
                return HttpNotFound();
            }
            return View(contratoReserva);
        }

        // POST: ContratoReservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoReserva contratoReserva = unityOfWork.ContratoReserva.Get(id);
            //db.Contratos.Remove(contratoReserva);
            unityOfWork.ContratoReserva.Delete(contratoReserva);
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
