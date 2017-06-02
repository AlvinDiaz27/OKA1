using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities.IRepositories
{
    public interface IUnityOfWork: IDisposable
    {
        //Cada una de las propiedades son de Lectura
        IClienteRepository Cliente { get; }
        IEmpleadoRepository Empleado { get; }
        IInmuebleRepository Inmueble { get; }
        ITipoInmuebleRepository TipoInmueble { get; }
        IBoletaRepository Boleta{ get; }
        IComprobanteRepository Comprobante { get; }
        IContratoAlquilerRepository ContratoAlquiler{ get; }
        IContratoRepository Contrato { get; }
        IContratoReservaRepository ContratoReserva { get; }
        IContratoVentaRepository ContratoVenta { get; }
        IDepartamentoRepository Departamento { get; }
        IDistritoRepository Distrito { get; }
        IFacturaRepository Factura { get; }
        IPropietarioRepository Propietario { get; }
        IProvinciaRepository Provincia { get; }
        IUbigeoRepository Ubigeo { get; }
        IVisitaRepository Visita { get; }

        //Guarda los cambios en la base de datos
        int SaveChanges();

        void StateModified(object entity);


       

    }
}
