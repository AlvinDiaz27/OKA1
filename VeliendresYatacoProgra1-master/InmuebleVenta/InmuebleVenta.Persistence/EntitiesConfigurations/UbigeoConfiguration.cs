using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class UbigeoConfiguration : EntityTypeConfiguration<Ubigeo>
    {
        public UbigeoConfiguration()
        {
            //tabla
            ToTable("Ubigeos");
            HasKey(u => u.UbigeoId);



            //Relaciones
            HasRequired(u => u.Departamento)
                .WithMany(d => d.Ubigeos)
                .HasForeignKey(d => d.DepartamentoId);


            HasRequired(u => u.Distrito)
                .WithMany(d => d.Ubigeos)
                .HasForeignKey(d => d.DistritoId);


            HasRequired(u => u.Provincia)
                .WithMany(d => d.Ubigeos)
                .HasForeignKey(d => d.ProvinciaId);


        }
    }
}