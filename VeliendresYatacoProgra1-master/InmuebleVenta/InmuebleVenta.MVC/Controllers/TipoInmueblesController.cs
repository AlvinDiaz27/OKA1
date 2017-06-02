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
    public class TipoInmueblesController : Controller
    {
        //private InmuebleVentaDbContext db = new InmuebleVentaDbContext();
        private UnityOfWork unityOfWork = UnityOfWork.Instance;
        // GET: TipoInmuebles
        public ActionResult Index()
        {
            //var inmuebles = db.Inmuebles.Include(t => t.Contrato).Include(t => t.Propietario).Include(t => t.Ubigeo);
            return View(unityOfWork.TipoInmueble.GetAll());
        }

        // GET: TipoInmuebles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            TipoInmueble tipoInmueble = unityOfWork.TipoInmueble.Get(id);
            if (tipoInmueble == null)
            {
                return HttpNotFound();
            }
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Create
        public ActionResult Create()
        {
            //ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente");
            //ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario");
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId");
            return View();
        }

        // POST: TipoInmuebles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InmuebleId,Estado,PrecioInmueble,DireccionInmueble,TipoInmuebleId,UbigeoId,PropietarioId,ContratoId,VisitaId,Descripcion,Tipo")] TipoInmueble tipoInmueble)
        {
            if (ModelState.IsValid)
            {
                unityOfWork.TipoInmueble.Add(tipoInmueble);
                //db.Inmuebles.Add(tipoInmueble);
                unityOfWork.SaveChanges();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", tipoInmueble.InmuebleId);
            //ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", tipoInmueble.PropietarioId);
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", tipoInmueble.UbigeoId);
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            TipoInmueble tipoInmueble = unityOfWork.TipoInmueble.Get(id);
            if (tipoInmueble == null)
            {
                return HttpNotFound();
            }
            //ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", tipoInmueble.InmuebleId);
            //ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", tipoInmueble.PropietarioId);
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", tipoInmueble.UbigeoId);
            return View(tipoInmueble);
        }

        // POST: TipoInmuebles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InmuebleId,Estado,PrecioInmueble,DireccionInmueble,TipoInmuebleId,UbigeoId,PropietarioId,ContratoId,VisitaId,Descripcion,Tipo")] TipoInmueble tipoInmueble)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tipoInmueble).State = EntityState.Modified;
                unityOfWork.StateModified(tipoInmueble);
                //db.SaveChanges();
                unityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", tipoInmueble.InmuebleId);
            //ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", tipoInmueble.PropietarioId);
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", tipoInmueble.UbigeoId);
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            TipoInmueble tipoInmueble = unityOfWork.TipoInmueble.Get(id);
            if (tipoInmueble == null)
            {
                return HttpNotFound();
            }
            return View(tipoInmueble);
        }

        // POST: TipoInmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            TipoInmueble tipoInmueble = unityOfWork.TipoInmueble.Get(id);
            //db.Inmuebles.Remove(tipoInmueble);
            unityOfWork.TipoInmueble.Delete(tipoInmueble);
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
