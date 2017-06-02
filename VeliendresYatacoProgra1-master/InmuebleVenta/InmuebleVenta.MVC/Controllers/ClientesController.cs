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
using InmuebleVenta.Persistence.Repositories;

namespace InmuebleVenta.MVC.Controllers
{
    public class ClientesController : Controller
    {
        //private InmuebleVentaDbContext db = new InmuebleVentaDbContext();
        // private readonly IUnityOfWork _UnityOfWork;
        private readonly UnityOfWork _UnityOfWork = UnityOfWork.Instance;
        /*public ClientesController(IUnityOfWork unityOfWork)
        {
            UnityOfWork = unityOfWork;
        }
        */
        public ClientesController() {


        }

        // GET: Clientes
        public ActionResult Index()
        {
            //return View(db.Clientes.ToList());
            return View(_UnityOfWork.Cliente.GetAll());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Cliente cliente = db.Clientes.Find(id);
            Cliente cliente = _UnityOfWork.Cliente.Get(id);

        
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteDNI,NombreCliente,ApeCliente,TelefonoCliente,DireccionCliente,VisitaId,ContratoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {

                _UnityOfWork.Cliente.Add(cliente);

               // db.Clientes.Add(cliente);

                _UnityOfWork.SaveChanges();

               // db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteDNI,NombreCliente,ApeCliente,TelefonoCliente,DireccionCliente,VisitaId,ContratoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cliente).State = EntityState.Modified;
                _UnityOfWork.StateModified(cliente);

                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            // db.Clientes.Remove(cliente);
            _UnityOfWork.Cliente.Delete(cliente);

            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
               
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
