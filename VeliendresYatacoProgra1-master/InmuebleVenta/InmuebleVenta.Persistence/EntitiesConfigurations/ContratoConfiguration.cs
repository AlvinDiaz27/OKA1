using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class ContratoConfiguration : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfiguration()
        {
            ToTable("Contrato");
            HasKey(a => a.ContratoId);
            Property(c => c.Fecha);

            //Multiplicidad
            Property(p => p.Fecha).IsRequired();


            Map<ContratoAlquiler>(m => m.Requires("Discriminator").HasValue("ContratoAlquiler"));
            Map<ContratoVenta>(m => m.Requires("Discriminator").HasValue("ContratoVenta"));
            Map<ContratoReserva>(m => m.Requires("Discriminator").HasValue("ContratoReserva"));


            //Relations Inmueble
            HasRequired(c => c.Inmueble)
            .WithRequiredPrincipal(c => c.Contrato);


            //Relations Empleado
            HasRequired(c => c.Empleado)
            .WithMany(c => c.Contratos)
            .HasForeignKey(v => v.EmpleadoDNI);

            //Relations  Cliente
            HasRequired(c => c.Cliente)
                .WithMany(c => c.Contratos)
                .HasForeignKey(v => v.ClienteDNI);
            // Relacion Propietario
            HasRequired(c => c.Propietario)
                 .WithRequiredPrincipal(c => c.Contrato);





        }
    }
}
