namespace InmuebleVenta.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comprobante",
                c => new
                    {
                        ComprobanteId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Monto = c.Double(nullable: false),
                        ContratoResarvaId = c.Int(nullable: false),
                        ContratoAlquilerId = c.Int(nullable: false),
                        ContratoAlquiler_ContratoId = c.Int(),
                        ContratoReserva_ContratoId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ComprobanteId)
                .ForeignKey("dbo.Contrato", t => t.ContratoAlquiler_ContratoId)
                .ForeignKey("dbo.Contrato", t => t.ContratoReserva_ContratoId)
                .Index(t => t.ContratoAlquiler_ContratoId)
                .Index(t => t.ContratoReserva_ContratoId);
            
            CreateTable(
                "dbo.Contrato",
                c => new
                    {
                        ContratoId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        ClienteDNI = c.Int(nullable: false),
                        NombreCliente = c.String(),
                        ApeCliente = c.String(),
                        PropietarioDNI = c.Int(nullable: false),
                        ApePropietario = c.String(),
                        NombrePropietario = c.String(),
                        InmuebleId = c.Int(nullable: false),
                        PrecioInmueble = c.Double(nullable: false),
                        EmpleadoDNI = c.Int(nullable: false),
                        NombreEmpleado = c.String(),
                        ApeEmpleado = c.String(),
                        CantMeses = c.Int(),
                        MontoMensual = c.Double(),
                        MontoCuotas = c.Double(),
                        FechaVenta = c.DateTime(),
                        Propietario_PropietarioDNI = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ContratoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteDNI, cascadeDelete: true)
                .ForeignKey("dbo.Propietario", t => t.Propietario_PropietarioDNI)
                .ForeignKey("dbo.Empleado", t => t.EmpleadoDNI, cascadeDelete: true)
                .Index(t => t.ClienteDNI)
                .Index(t => t.EmpleadoDNI)
                .Index(t => t.Propietario_PropietarioDNI);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteDNI = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(),
                        ApeCliente = c.String(),
                        TelefonoCliente = c.Int(nullable: false),
                        DireccionCliente = c.Int(nullable: false),
                        VisitaId = c.Int(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        Contrato_ContratoId = c.Int(),
                        Visita_VisitaId = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteDNI)
                .ForeignKey("dbo.Contrato", t => t.Contrato_ContratoId)
                .ForeignKey("dbo.Visitas", t => t.Visita_VisitaId)
                .Index(t => t.Contrato_ContratoId)
                .Index(t => t.Visita_VisitaId);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        EmpleadoDNI = c.Int(nullable: false, identity: true),
                        NombreEmpleado = c.String(),
                        ApeEmpleado = c.String(),
                        TelefonoEmpleado = c.Int(nullable: false),
                        DireccionEmpleado = c.String(),
                        VisitaId = c.Int(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        Contrato_ContratoId = c.Int(),
                        Visita_VisitaId = c.Int(),
                    })
                .PrimaryKey(t => t.EmpleadoDNI)
                .ForeignKey("dbo.Contrato", t => t.Contrato_ContratoId)
                .ForeignKey("dbo.Visitas", t => t.Visita_VisitaId)
                .Index(t => t.Contrato_ContratoId)
                .Index(t => t.Visita_VisitaId);
            
            CreateTable(
                "dbo.Visitas",
                c => new
                    {
                        VisitaId = c.Int(nullable: false, identity: true),
                        FechaVisita = c.DateTime(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleado", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Inmueble",
                c => new
                    {
                        InmuebleId = c.Int(nullable: false),
                        Estado = c.String(nullable: false),
                        PrecioInmueble = c.Double(nullable: false),
                        DireccionInmueble = c.String(nullable: false),
                        TipoInmuebleId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                        PropietarioId = c.Int(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        VisitaId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Tipo = c.Int(),
                        Discriminator = c.String(maxLength: 128),
                        TipoInmueble_InmuebleId = c.Int(),
                        Inmueble_InmuebleId = c.Int(),
                        Visita_VisitaId = c.Int(),
                    })
                .PrimaryKey(t => t.InmuebleId)
                .ForeignKey("dbo.Propietario", t => t.PropietarioId, cascadeDelete: true)
                .ForeignKey("dbo.Inmueble", t => t.TipoInmueble_InmuebleId)
                .ForeignKey("dbo.Inmueble", t => t.Inmueble_InmuebleId)
                .ForeignKey("dbo.Ubigeos", t => t.UbigeoId, cascadeDelete: true)
                .ForeignKey("dbo.Visitas", t => t.Visita_VisitaId)
                .ForeignKey("dbo.Contrato", t => t.InmuebleId)
                .Index(t => t.InmuebleId)
                .Index(t => t.UbigeoId)
                .Index(t => t.PropietarioId)
                .Index(t => t.TipoInmueble_InmuebleId)
                .Index(t => t.Inmueble_InmuebleId)
                .Index(t => t.Visita_VisitaId);
            
            CreateTable(
                "dbo.Propietario",
                c => new
                    {
                        PropietarioDNI = c.Int(nullable: false),
                        NombrePropietario = c.String(),
                        ApePropietario = c.String(),
                        TelefonoPropietario = c.Int(nullable: false),
                        DireccionPropietario = c.String(),
                        InmuebleId = c.Int(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        Inmueble_InmuebleId = c.Int(),
                    })
                .PrimaryKey(t => t.PropietarioDNI)
                .ForeignKey("dbo.Inmueble", t => t.Inmueble_InmuebleId)
                .ForeignKey("dbo.Contrato", t => t.PropietarioDNI)
                .Index(t => t.PropietarioDNI)
                .Index(t => t.Inmueble_InmuebleId);
            
            CreateTable(
                "dbo.Ubigeos",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false, identity: true),
                        DepartamentoId = c.Int(nullable: false),
                        ProvinciaId = c.Int(nullable: false),
                        DistritoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UbigeoId)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Distrito", t => t.DistritoId, cascadeDelete: true)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.DepartamentoId)
                .Index(t => t.ProvinciaId)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DistritoId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.VisitasInmuebles",
                c => new
                    {
                        VisitaId = c.Int(nullable: false),
                        InmuebleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisitaId, t.InmuebleId })
                .ForeignKey("dbo.Visitas", t => t.VisitaId, cascadeDelete: true)
                .ForeignKey("dbo.Inmueble", t => t.InmuebleId, cascadeDelete: true)
                .Index(t => t.VisitaId)
                .Index(t => t.InmuebleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comprobante", "ContratoReserva_ContratoId", "dbo.Contrato");
            DropForeignKey("dbo.Comprobante", "ContratoAlquiler_ContratoId", "dbo.Contrato");
            DropForeignKey("dbo.Cliente", "Visita_VisitaId", "dbo.Visitas");
            DropForeignKey("dbo.Cliente", "Contrato_ContratoId", "dbo.Contrato");
            DropForeignKey("dbo.Propietario", "PropietarioDNI", "dbo.Contrato");
            DropForeignKey("dbo.Inmueble", "InmuebleId", "dbo.Contrato");
            DropForeignKey("dbo.Contrato", "EmpleadoDNI", "dbo.Empleado");
            DropForeignKey("dbo.Empleado", "Visita_VisitaId", "dbo.Visitas");
            DropForeignKey("dbo.VisitasInmuebles", "InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.VisitasInmuebles", "VisitaId", "dbo.Visitas");
            DropForeignKey("dbo.Inmueble", "Visita_VisitaId", "dbo.Visitas");
            DropForeignKey("dbo.Inmueble", "UbigeoId", "dbo.Ubigeos");
            DropForeignKey("dbo.Inmueble", "Inmueble_InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.Inmueble", "TipoInmueble_InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.Ubigeos", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Ubigeos", "DistritoId", "dbo.Distrito");
            DropForeignKey("dbo.Ubigeos", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Inmueble", "PropietarioId", "dbo.Propietario");
            DropForeignKey("dbo.Propietario", "Inmueble_InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.Contrato", "Propietario_PropietarioDNI", "dbo.Propietario");
            DropForeignKey("dbo.Visitas", "EmpleadoId", "dbo.Empleado");
            DropForeignKey("dbo.Visitas", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Empleado", "Contrato_ContratoId", "dbo.Contrato");
            DropForeignKey("dbo.Contrato", "ClienteDNI", "dbo.Cliente");
            DropIndex("dbo.VisitasInmuebles", new[] { "InmuebleId" });
            DropIndex("dbo.VisitasInmuebles", new[] { "VisitaId" });
            DropIndex("dbo.Ubigeos", new[] { "DistritoId" });
            DropIndex("dbo.Ubigeos", new[] { "ProvinciaId" });
            DropIndex("dbo.Ubigeos", new[] { "DepartamentoId" });
            DropIndex("dbo.Propietario", new[] { "Inmueble_InmuebleId" });
            DropIndex("dbo.Propietario", new[] { "PropietarioDNI" });
            DropIndex("dbo.Inmueble", new[] { "Visita_VisitaId" });
            DropIndex("dbo.Inmueble", new[] { "Inmueble_InmuebleId" });
            DropIndex("dbo.Inmueble", new[] { "TipoInmueble_InmuebleId" });
            DropIndex("dbo.Inmueble", new[] { "PropietarioId" });
            DropIndex("dbo.Inmueble", new[] { "UbigeoId" });
            DropIndex("dbo.Inmueble", new[] { "InmuebleId" });
            DropIndex("dbo.Visitas", new[] { "ClienteId" });
            DropIndex("dbo.Visitas", new[] { "EmpleadoId" });
            DropIndex("dbo.Empleado", new[] { "Visita_VisitaId" });
            DropIndex("dbo.Empleado", new[] { "Contrato_ContratoId" });
            DropIndex("dbo.Cliente", new[] { "Visita_VisitaId" });
            DropIndex("dbo.Cliente", new[] { "Contrato_ContratoId" });
            DropIndex("dbo.Contrato", new[] { "Propietario_PropietarioDNI" });
            DropIndex("dbo.Contrato", new[] { "EmpleadoDNI" });
            DropIndex("dbo.Contrato", new[] { "ClienteDNI" });
            DropIndex("dbo.Comprobante", new[] { "ContratoReserva_ContratoId" });
            DropIndex("dbo.Comprobante", new[] { "ContratoAlquiler_ContratoId" });
            DropTable("dbo.VisitasInmuebles");
            DropTable("dbo.Provincia");
            DropTable("dbo.Distrito");
            DropTable("dbo.Departamento");
            DropTable("dbo.Ubigeos");
            DropTable("dbo.Propietario");
            DropTable("dbo.Inmueble");
            DropTable("dbo.Visitas");
            DropTable("dbo.Empleado");
            DropTable("dbo.Cliente");
            DropTable("dbo.Contrato");
            DropTable("dbo.Comprobante");
        }
    }
}
