using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class InmuebleConfiguration : EntityTypeConfiguration<Inmueble>
    {

        public InmuebleConfiguration()
        {
            //Table Configurations
            ToTable("Inmueble");

            //Herencia Simple
            HasKey(a => a.InmuebleId);
            Property(p => p.InmuebleId).IsRequired();
            Property(p => p.Estado).IsRequired();
            Property(p => p.PrecioInmueble).IsRequired();
            Property(p => p.DireccionInmueble).IsRequired();

            Map<TipoInmueble>(m => m.Requires("Discriminator").HasValue("Inmueble"));




            //Relations Propietario
            HasRequired(c => c.Propietario)
                .WithMany(c => c.Inmuebles)
                .HasForeignKey(v => v.PropietarioId);



        }
    }
}
