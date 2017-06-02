using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        //Configuracion de la Tabla
        public DistritoConfiguration()
        {
            ToTable("Distrito");
            HasKey(d => d.DistritoId);
            Property(c => c.Nombre);


        }
    }
}