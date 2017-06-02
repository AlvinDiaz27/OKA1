using InmuebleVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.EntitiesConfigurations
{
    public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {
        //COnfiguracion de la Tabla
        public DepartamentoConfiguration()
        {
            ToTable("Departamento");
            HasKey(d => d.DepartamentoId);
            Property(c => c.Nombre);


        }
    }
}

