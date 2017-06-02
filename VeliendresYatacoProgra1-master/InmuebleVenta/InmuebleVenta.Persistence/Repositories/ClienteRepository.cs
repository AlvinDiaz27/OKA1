using InmuebleVenta.Entities;
using InmuebleVenta.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(InmuebleVentaDbContext context) : base(context)
        {

        }


        /* private readonly InmuebleVentaDbContext _Context;

         private ClienteRepository()
         {

         }

         public ClienteRepository(InmuebleVentaDbContext context)
         {
             _Context = context;
         }


         IEnumerable<Cliente> IClienteRepository.getClienteWithContrato(Contrato Contrato)
         {
             throw new NotImplementedException();
         }

         IEnumerable<Cliente> IClienteRepository.getClienteWithVisita(Visita Visita)
         {
             throw new NotImplementedException();
         }
         */
    }
}
