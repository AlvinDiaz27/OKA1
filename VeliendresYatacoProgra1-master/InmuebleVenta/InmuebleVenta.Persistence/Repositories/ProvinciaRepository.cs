using InmuebleVenta.Entities;
using InmuebleVenta.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class ProvinciaRepository : Repository<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(InmuebleVentaDbContext context) : base(context)
        {

        }





        /*private readonly InmuebleVentaDbContext _Context;

        public ProvinciaRepository(InmuebleVentaDbContext context)
        {
            _Context = context;
        }

        private ProvinciaRepository()
        {

        }
        */
    }
}
