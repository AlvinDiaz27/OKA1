using InmuebleVenta.Entities;
using InmuebleVenta.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(InmuebleVentaDbContext context) : base(context)
        {

        }


        /* private readonly InmuebleVentaDbContext _Context;

        public ContratoRepository(InmuebleVentaDbContext context)
        {
            _Context = context;
        }

        private ContratoRepository()
        {

        }
        */
    }
}
