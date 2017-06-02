using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class VisitaConfiguration : EntityTypeConfiguration<Visita>
    {
        public VisitaConfiguration()
        {
            //Table Configurations
            ToTable("Visitas");

            HasKey(a => a.VisitaId);
            Property(c => c.FechaVisita);

            //Relations Cliente
            HasRequired(c => c.Cliente)
                .WithMany(c => c.Visitas)
                .HasForeignKey(v => v.ClienteId);


            //Relations Empleado
            HasRequired(c => c.Empleado)
                .WithMany(c => c.Visitas)
                .HasForeignKey(v => v.EmpleadoId);

            //Relacion Multiplicidad Inmueble
            HasMany(c => c.Inmuebles)
                .WithMany(c => c.Visitas)
                .Map(m =>
                {
                    m.ToTable("VisitasInmuebles");
                    m.MapLeftKey("VisitaId");
                    m.MapRightKey("InmuebleId");
                });

        }

    }

}