using InmuebleVenta.Entities;
using InmuebleVenta.Persistence.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence
{
    public class InmuebleVentaDbContext : DbContext
    {
        public DbSet<Boleta> Boletas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Comprobante> Comprobantes { get; set; }

        public DbSet<Contrato> Contratos { get; set; }

        public DbSet<ContratoAlquiler> ContratosAlquileres { get; set; }
        public DbSet<ContratoVenta> ContratosVentas { get; set; }

        public DbSet<ContratoReserva> ContratosReservas { get; set; }

        public DbSet<Distrito> Distritos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<Propietario> Propietarios { get; set; }

        public DbSet<Provincia> Provinciass { get; set; }

        public DbSet<TipoInmueble> TiposInmuebles { get; set; }

        public DbSet<Visita> Visitas { get; set; }


        public DbSet<Inmueble> Inmuebles { get; set; }

        public DbSet<Ubigeo> Ubigeos { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UbigeoConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ComprobanteConfiguration());
            modelBuilder.Configurations.Add(new PropietarionConfiguration());
            modelBuilder.Configurations.Add(new InmuebleConfiguration());
           
            modelBuilder.Configurations.Add(new ContratoConfiguration());
            modelBuilder.Configurations.Add(new VisitaConfiguration());
            modelBuilder.Configurations.Add(new EmpleadoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    
    }
}
