using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class ProvinciaConfiguration : EntityTypeConfiguration<Provincia>
    {
        //Configuracion de Tabla
        public ProvinciaConfiguration()
        {
            ToTable("Provincia");
            HasKey(d => d.ProvinciaId);
            Property(c => c.Nombre);


        }

    }
}