using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class EmpleadoConfiguration : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguration()
        {
            //Table Configurations
            ToTable("Empleado");

            HasKey(a => a.EmpleadoDNI);
            Property(c => c.NombreEmpleado);
            Property(c => c.ApeEmpleado);
            Property(c => c.TelefonoEmpleado);
            Property(c => c.DireccionEmpleado);
        }
    }
}
