using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //Table Configurations
            ToTable("Cliente");

            HasKey(a => a.ClienteDNI);
            Property(c => c.NombreCliente);
            Property(c => c.ApeCliente);
            Property(c => c.TelefonoCliente);
            Property(c => c.DireccionCliente);


        }
    }
}