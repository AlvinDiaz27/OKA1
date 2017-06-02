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
    public class ContratoVentasController : Controller
    {
        // private InmuebleVentaDbContext db = new InmuebleVentaDbContext();
        private readonly UnityOfWork unityOfWork = UnityOfWork.Instance;
        // GET: ContratoVentas
        public ActionResult Index()
        {
            //var contratos = db.Contratos.Include(c => c.Cliente).Include(c => c.Empleado);
            return View(unityOfWork.ContratoVenta.GetAll());
        }

        // GET: ContratoVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoVenta contratoVenta = unityOfWork.ContratoVenta.Get(id);
            if (contratoVenta == null)
            {
                return HttpNotFound();
            }
            return View(contratoVenta);
        }

        // GET: ContratoVentas/Create
        public ActionResult Create()
        {
            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente");
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado");
            return View();
        }

        // POST: ContratoVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,Fecha,ClienteDNI,NombreCliente,ApeCliente,PropietarioDNI,ApePropietario,NombrePropietario,InmuebleId,PrecioInmueble,EmpleadoDNI,NombreEmpleado,ApeEmpleado,FechaVenta")] ContratoVenta contratoVenta)
        {
            if (ModelState.IsValid)
            {
                //db.Contratos.Add(contratoVenta);
                unityOfWork.ContratoVenta.Add(contratoVenta);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoVenta.ClienteDNI);
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoVenta.EmpleadoDNI);
            return View(contratoVenta);
        }

        // GET: ContratoVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoVenta contratoVenta = unityOfWork.ContratoVenta.Get(id);
            if (contratoVenta == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoVenta.ClienteDNI);
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoVenta.EmpleadoDNI);
            return View(contratoVenta);
        }

        // POST: ContratoVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,Fecha,ClienteDNI,NombreCliente,ApeCliente,PropietarioDNI,ApePropietario,NombrePropietario,InmuebleId,PrecioInmueble,EmpleadoDNI,NombreEmpleado,ApeEmpleado,FechaVenta")] ContratoVenta contratoVenta)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contratoVenta).State = EntityState.Modified;
                unityOfWork.StateModified(contratoVenta);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoVenta.ClienteDNI);
            //ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoVenta.EmpleadoDNI);
            return View(contratoVenta);
        }

        // GET: ContratoVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoVenta contratoVenta = unityOfWork.ContratoVenta.Get(id);
            if (contratoVenta == null)
            {
                return HttpNotFound();
            }
            return View(contratoVenta);
        }

        // POST: ContratoVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoVenta contratoVenta = unityOfWork.ContratoVenta.Get(id);
            //db.Contratos.Remove(contratoVenta);
            unityOfWork.ContratoVenta.Delete(contratoVenta);
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
