using InmuebleVenta.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly InmuebleVentaDbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IClienteRepository Cliente { get; private set; }

        public IEmpleadoRepository Empleado { get; private set; }

        public IInmuebleRepository Inmueble { get; private set; }

        public ITipoInmuebleRepository TipoInmueble { get; private set; }

        public IBoletaRepository Boleta { get; private set; }

        public IComprobanteRepository Comprobante { get; private set; }

        public IContratoAlquilerRepository ContratoAlquiler { get; private set; }

        public IContratoRepository Contrato { get; private set; }

        public IContratoReservaRepository ContratoReserva { get; private set; }

        public IContratoVentaRepository ContratoVenta { get; private set; }

        public IDepartamentoRepository Departamento { get; private set; }

        public IDistritoRepository Distrito { get; private set; }

        public IFacturaRepository Factura { get; private set; }

        public IPropietarioRepository Propietario  { get; private set; }

        public IProvinciaRepository Provincia { get; private set; }

        public IUbigeoRepository Ubigeo { get; private set; }

        public IVisitaRepository Visita { get; private set; }

        private UnityOfWork()
        {
            _Context = new InmuebleVentaDbContext();
            Boleta = new BoletaRepository(_Context);
            Cliente = new ClienteRepository(_Context);
            Comprobante = new ComprobanteRepository(_Context);
            ContratoAlquiler = new ContratoAlquilerRepository(_Context);
            Contrato = new ContratoRepository(_Context);
            ContratoReserva = new ContratoReservaRepository(_Context);
            ContratoVenta = new ContratoVentaRepository(_Context);
            Departamento = new DepartamentoRepository(_Context);
            Distrito= new DistritoRepository(_Context);
            Empleado = new EmpleadoRepository(_Context);
            Factura = new FacturaRepository(_Context);
            Inmueble= new InmuebleRepository(_Context);
            Propietario = new PropietarioRepository(_Context);
            Provincia = new ProvinciaRepository(_Context);
            TipoInmueble = new TipoInmuebleRepository(_Context);
            Ubigeo= new UbigeoRepository(_Context);
            Visita = new VisitaRepository(_Context);



        }
       
         public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }

                return _Instance;
            }
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

       public  int SaveChanges()
        {
            return _Context.SaveChanges() ;
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }

    }
}
