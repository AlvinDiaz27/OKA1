using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities.IRepositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {

        //IEnumerable<Cliente> getClienteWithVisita(Visita Visita);
        //IEnumerable<Cliente> getClienteWithContrato(Contrato Contrato);
        //IEnumerable<BasedeDatos> getBasedeDatosWithCuenta(Cuenta Cuenta);
    }
}
