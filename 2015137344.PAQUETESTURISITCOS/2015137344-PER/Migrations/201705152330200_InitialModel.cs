namespace _2015137344_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiciosTuristicos",
                c => new
                    {
                        ServicioTuristicoId = c.Int(nullable: false, identity: true),
                        PrecioServicioTuristico = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioTuristicoId);
            
            CreateTable(
                "dbo.CategoriasAlimentacion",
                c => new
                    {
                        CategoriaAlimentacionId = c.Int(nullable: false, identity: true),
                        NomCategoriaAlimentacion = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoriaAlimentacionId);
            
            CreateTable(
                "dbo.Paquetes",
                c => new
                    {
                        PaqueteId = c.Int(nullable: false, identity: true),
                        NomPaquete = c.String(nullable: false, maxLength: 255),
                        PrecioPaquete = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaqueteId);
            
            CreateTable(
                "dbo.CalificacionesHospedaje",
                c => new
                    {
                        CalificacionHospedajeId = c.Int(nullable: false, identity: true),
                        Calificacion = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CalificacionHospedajeId);
            
            CreateTable(
                "dbo.CategoriasHospedaje",
                c => new
                    {
                        CategoriaHospedajeId = c.Int(nullable: false, identity: true),
                        NomCategoriaHospedaje = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoriaHospedajeId);
            
            CreateTable(
                "dbo.ServiciosHospedaje",
                c => new
                    {
                        ServicioHospedajeId = c.Int(nullable: false, identity: true),
                        NomServicioHospedaje = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ServicioHospedajeId);
            
            CreateTable(
                "dbo.TiposHospedaje",
                c => new
                    {
                        TipoHospedajeId = c.Int(nullable: false, identity: true),
                        NomTipoHospedaje = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.TipoHospedajeId);
            
            CreateTable(
                "dbo.CategoriasTransporte",
                c => new
                    {
                        CategoriaTransporteId = c.Int(nullable: false, identity: true),
                        NomCategoriaTransporte = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoriaTransporteId);
            
            CreateTable(
                "dbo.TiposTransporte",
                c => new
                    {
                        TipoTransporteId = c.Int(nullable: false, identity: true),
                        NomTipoTransporte = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.TipoTransporteId);
            
            CreateTable(
                "dbo.VentasPaquetes",
                c => new
                    {
                        VentaPaqueteId = c.Int(nullable: false, identity: true),
                        MontoAPagar = c.Double(nullable: false),
                        MedioPagoId = c.Int(nullable: false),
                        ComprobantePagoId = c.Int(nullable: false),
                        Cliente_PersonaId = c.Int(nullable: false),
                        Empleado_PersonaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaPaqueteId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_PersonaId)
                .ForeignKey("dbo.Empleados", t => t.Empleado_PersonaId)
                .ForeignKey("dbo.MediosPago", t => t.MedioPagoId, cascadeDelete: true)
                .Index(t => t.MedioPagoId)
                .Index(t => t.Cliente_PersonaId)
                .Index(t => t.Empleado_PersonaId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        DocIdPersona = c.Int(nullable: false),
                        NomPersona = c.String(nullable: false, maxLength: 255),
                        ApePatPersona = c.String(nullable: false, maxLength: 255),
                        ApeMatPersona = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.ComprobantesPago",
                c => new
                    {
                        ComprobantePagoId = c.Int(nullable: false),
                        NumComprobantePago = c.Int(nullable: false),
                        TipoComprobanteId = c.Int(nullable: false),
                        VentaPaqueteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComprobantePagoId)
                .ForeignKey("dbo.TiposComprobante", t => t.TipoComprobanteId, cascadeDelete: true)
                .ForeignKey("dbo.VentasPaquetes", t => t.ComprobantePagoId)
                .Index(t => t.ComprobantePagoId)
                .Index(t => t.TipoComprobanteId);
            
            CreateTable(
                "dbo.TiposComprobante",
                c => new
                    {
                        TipoComprobanteId = c.Int(nullable: false, identity: true),
                        NomTipoComprobante = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.TipoComprobanteId);
            
            CreateTable(
                "dbo.MediosPago",
                c => new
                    {
                        MedioPagoId = c.Int(nullable: false, identity: true),
                        NomMedioPago = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.MedioPagoId);
            
            CreateTable(
                "dbo.DetalleHospedajeServiciosHospedaje",
                c => new
                    {
                        ServicioTuristicoId = c.Int(nullable: false),
                        ServicioHospedajeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServicioTuristicoId, t.ServicioHospedajeId })
                .ForeignKey("dbo.Hospedajes", t => t.ServicioTuristicoId, cascadeDelete: true)
                .ForeignKey("dbo.ServiciosHospedaje", t => t.ServicioHospedajeId, cascadeDelete: true)
                .Index(t => t.ServicioTuristicoId)
                .Index(t => t.ServicioHospedajeId);
            
            CreateTable(
                "dbo.DetallePaqueteServiciosTuristicos",
                c => new
                    {
                        PaqueteId = c.Int(nullable: false),
                        ServicioTuristicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaqueteId, t.ServicioTuristicoId })
                .ForeignKey("dbo.Paquetes", t => t.PaqueteId, cascadeDelete: true)
                .ForeignKey("dbo.ServiciosTuristicos", t => t.ServicioTuristicoId, cascadeDelete: true)
                .Index(t => t.PaqueteId)
                .Index(t => t.ServicioTuristicoId);
            
            CreateTable(
                "dbo.DetalleVentaPaquetes",
                c => new
                    {
                        VentaPaqueteId = c.Int(nullable: false),
                        PaqueteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaPaqueteId, t.PaqueteId })
                .ForeignKey("dbo.VentasPaquetes", t => t.VentaPaqueteId, cascadeDelete: true)
                .ForeignKey("dbo.Paquetes", t => t.PaqueteId, cascadeDelete: true)
                .Index(t => t.VentaPaqueteId)
                .Index(t => t.PaqueteId);
            
            CreateTable(
                "dbo.Alimentaciones",
                c => new
                    {
                        ServicioTuristicoId = c.Int(nullable: false),
                        NomEstablecimiento = c.String(nullable: false, maxLength: 255),
                        CategoriaAlimentacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioTuristicoId)
                .ForeignKey("dbo.ServiciosTuristicos", t => t.ServicioTuristicoId)
                .ForeignKey("dbo.CategoriasAlimentacion", t => t.CategoriaAlimentacionId, cascadeDelete: true)
                .Index(t => t.ServicioTuristicoId)
                .Index(t => t.CategoriaAlimentacionId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        Correo = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.Personas", t => t.PersonaId)
                .Index(t => t.PersonaId);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        PersonaId = c.Int(nullable: false),
                        Sueldo = c.Double(nullable: false),
                        FechaContrato = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.Personas", t => t.PersonaId)
                .Index(t => t.PersonaId);
            
            CreateTable(
                "dbo.Hospedajes",
                c => new
                    {
                        ServicioTuristicoId = c.Int(nullable: false),
                        NomHospedaje = c.String(nullable: false, maxLength: 255),
                        TipoHospedajeId = c.Int(nullable: false),
                        CalificacionHospedajeId = c.Int(nullable: false),
                        CategoriaHospedajeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioTuristicoId)
                .ForeignKey("dbo.ServiciosTuristicos", t => t.ServicioTuristicoId)
                .ForeignKey("dbo.TiposHospedaje", t => t.TipoHospedajeId, cascadeDelete: true)
                .ForeignKey("dbo.CalificacionesHospedaje", t => t.CalificacionHospedajeId, cascadeDelete: true)
                .ForeignKey("dbo.CategoriasHospedaje", t => t.CategoriaHospedajeId, cascadeDelete: true)
                .Index(t => t.ServicioTuristicoId)
                .Index(t => t.TipoHospedajeId)
                .Index(t => t.CalificacionHospedajeId)
                .Index(t => t.CategoriaHospedajeId);
            
            CreateTable(
                "dbo.Transportes",
                c => new
                    {
                        ServicioTuristicoId = c.Int(nullable: false),
                        NomEmpresaTransporte = c.String(nullable: false, maxLength: 255),
                        TipoTransporteId = c.Int(nullable: false),
                        CategoriaTransporteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicioTuristicoId)
                .ForeignKey("dbo.ServiciosTuristicos", t => t.ServicioTuristicoId)
                .ForeignKey("dbo.TiposTransporte", t => t.TipoTransporteId, cascadeDelete: true)
                .ForeignKey("dbo.CategoriasTransporte", t => t.CategoriaTransporteId, cascadeDelete: true)
                .Index(t => t.ServicioTuristicoId)
                .Index(t => t.TipoTransporteId)
                .Index(t => t.CategoriaTransporteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transportes", "CategoriaTransporteId", "dbo.CategoriasTransporte");
            DropForeignKey("dbo.Transportes", "TipoTransporteId", "dbo.TiposTransporte");
            DropForeignKey("dbo.Transportes", "ServicioTuristicoId", "dbo.ServiciosTuristicos");
            DropForeignKey("dbo.Hospedajes", "CategoriaHospedajeId", "dbo.CategoriasHospedaje");
            DropForeignKey("dbo.Hospedajes", "CalificacionHospedajeId", "dbo.CalificacionesHospedaje");
            DropForeignKey("dbo.Hospedajes", "TipoHospedajeId", "dbo.TiposHospedaje");
            DropForeignKey("dbo.Hospedajes", "ServicioTuristicoId", "dbo.ServiciosTuristicos");
            DropForeignKey("dbo.Empleados", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Clientes", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Alimentaciones", "CategoriaAlimentacionId", "dbo.CategoriasAlimentacion");
            DropForeignKey("dbo.Alimentaciones", "ServicioTuristicoId", "dbo.ServiciosTuristicos");
            DropForeignKey("dbo.DetalleVentaPaquetes", "PaqueteId", "dbo.Paquetes");
            DropForeignKey("dbo.DetalleVentaPaquetes", "VentaPaqueteId", "dbo.VentasPaquetes");
            DropForeignKey("dbo.VentasPaquetes", "MedioPagoId", "dbo.MediosPago");
            DropForeignKey("dbo.VentasPaquetes", "Empleado_PersonaId", "dbo.Empleados");
            DropForeignKey("dbo.ComprobantesPago", "ComprobantePagoId", "dbo.VentasPaquetes");
            DropForeignKey("dbo.ComprobantesPago", "TipoComprobanteId", "dbo.TiposComprobante");
            DropForeignKey("dbo.VentasPaquetes", "Cliente_PersonaId", "dbo.Clientes");
            DropForeignKey("dbo.DetallePaqueteServiciosTuristicos", "ServicioTuristicoId", "dbo.ServiciosTuristicos");
            DropForeignKey("dbo.DetallePaqueteServiciosTuristicos", "PaqueteId", "dbo.Paquetes");
            DropForeignKey("dbo.DetalleHospedajeServiciosHospedaje", "ServicioHospedajeId", "dbo.ServiciosHospedaje");
            DropForeignKey("dbo.DetalleHospedajeServiciosHospedaje", "ServicioTuristicoId", "dbo.Hospedajes");
            DropIndex("dbo.Transportes", new[] { "CategoriaTransporteId" });
            DropIndex("dbo.Transportes", new[] { "TipoTransporteId" });
            DropIndex("dbo.Transportes", new[] { "ServicioTuristicoId" });
            DropIndex("dbo.Hospedajes", new[] { "CategoriaHospedajeId" });
            DropIndex("dbo.Hospedajes", new[] { "CalificacionHospedajeId" });
            DropIndex("dbo.Hospedajes", new[] { "TipoHospedajeId" });
            DropIndex("dbo.Hospedajes", new[] { "ServicioTuristicoId" });
            DropIndex("dbo.Empleados", new[] { "PersonaId" });
            DropIndex("dbo.Clientes", new[] { "PersonaId" });
            DropIndex("dbo.Alimentaciones", new[] { "CategoriaAlimentacionId" });
            DropIndex("dbo.Alimentaciones", new[] { "ServicioTuristicoId" });
            DropIndex("dbo.DetalleVentaPaquetes", new[] { "PaqueteId" });
            DropIndex("dbo.DetalleVentaPaquetes", new[] { "VentaPaqueteId" });
            DropIndex("dbo.DetallePaqueteServiciosTuristicos", new[] { "ServicioTuristicoId" });
            DropIndex("dbo.DetallePaqueteServiciosTuristicos", new[] { "PaqueteId" });
            DropIndex("dbo.DetalleHospedajeServiciosHospedaje", new[] { "ServicioHospedajeId" });
            DropIndex("dbo.DetalleHospedajeServiciosHospedaje", new[] { "ServicioTuristicoId" });
            DropIndex("dbo.ComprobantesPago", new[] { "TipoComprobanteId" });
            DropIndex("dbo.ComprobantesPago", new[] { "ComprobantePagoId" });
            DropIndex("dbo.VentasPaquetes", new[] { "Empleado_PersonaId" });
            DropIndex("dbo.VentasPaquetes", new[] { "Cliente_PersonaId" });
            DropIndex("dbo.VentasPaquetes", new[] { "MedioPagoId" });
            DropTable("dbo.Transportes");
            DropTable("dbo.Hospedajes");
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Alimentaciones");
            DropTable("dbo.DetalleVentaPaquetes");
            DropTable("dbo.DetallePaqueteServiciosTuristicos");
            DropTable("dbo.DetalleHospedajeServiciosHospedaje");
            DropTable("dbo.MediosPago");
            DropTable("dbo.TiposComprobante");
            DropTable("dbo.ComprobantesPago");
            DropTable("dbo.Personas");
            DropTable("dbo.VentasPaquetes");
            DropTable("dbo.TiposTransporte");
            DropTable("dbo.CategoriasTransporte");
            DropTable("dbo.TiposHospedaje");
            DropTable("dbo.ServiciosHospedaje");
            DropTable("dbo.CategoriasHospedaje");
            DropTable("dbo.CalificacionesHospedaje");
            DropTable("dbo.Paquetes");
            DropTable("dbo.CategoriasAlimentacion");
            DropTable("dbo.ServiciosTuristicos");
        }
    }
}
