    using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class ComprobanteConfiguration : EntityTypeConfiguration<Comprobante>
    {
        public ComprobanteConfiguration()
        {
            ToTable("Comprobante");
            HasKey(a => a.ComprobanteId);
            Property(c => c.Fecha);
            Property(c => c.Monto);

            //Multiplicidad
            Property(p => p.Fecha).IsRequired();
            Property(p => p.Monto).IsRequired();


            Map<Boleta>(m => m.Requires("Discriminator").HasValue("Boleta"));
            Map<Factura>(m => m.Requires("Discriminator").HasValue("Factura"));

        }



    }
}
