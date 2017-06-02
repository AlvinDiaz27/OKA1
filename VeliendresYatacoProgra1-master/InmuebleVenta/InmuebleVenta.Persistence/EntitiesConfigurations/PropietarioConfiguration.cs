using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class PropietarionConfiguration : EntityTypeConfiguration<Propietario>
    {
        //Configuracion de Tablas
        public PropietarionConfiguration()
        {
            ToTable("Propietario");

            HasKey(a => a.PropietarioDNI);
            Property(c => c.NombrePropietario);
            Property(c => c.ApePropietario);
            Property(c => c.TelefonoPropietario);
            Property(c => c.DireccionPropietario);
        }
    }
}