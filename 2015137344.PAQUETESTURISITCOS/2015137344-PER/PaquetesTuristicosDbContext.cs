using _2015137344_ENT.Entities;
using _2015137344_PER.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER
{
    public class PaquetesTuristicosDbContext : DbContext
    {
        public DbSet<Alimentacion> Alimentaciones { get; set; }
        public DbSet<CalificacionHospedaje> CalificacionesHospedaje { get; set; }
        public DbSet<CategoriaAlimentacion> CategoriasAlimentacion { get; set; }
        public DbSet<CategoriaHospedaje> CategoriasHospedaje { get; set; }
        public DbSet<CategoriaTransporte> CategoriasTransporte { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ComprobantePago> ComprobantesPago { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Hospedaje> Hospedajes { get; set; }
        public DbSet<MedioPago> MediosPago { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<ServicioHospedaje> ServiciosHospedaje { get; set; }
        public DbSet<ServicioTuristico> ServiciosTuristicos { get; set; }
        public DbSet<TipoComprobante> TiposComprobante { get; set; }
        public DbSet<TipoHospedaje> TiposHospedaje { get; set; }
        public DbSet<TipoTransporte> TiposTransporte { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<VentaPaquete> VentasPaquetes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlimentacionConfiguration());
            modelBuilder.Configurations.Add(new CalificacionHospedajeConfiguration());
            modelBuilder.Configurations.Add(new CategoriaAlimentacionConfiguration());
            modelBuilder.Configurations.Add(new CategoriaHospedajeConfiguration());
            modelBuilder.Configurations.Add(new CategoriaTransporteConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ComprobantePagoConfiguration());
            modelBuilder.Configurations.Add(new EmpleadoConfiguration());
            modelBuilder.Configurations.Add(new HospedajeConfiguration());
            modelBuilder.Configurations.Add(new MedioPagoConfiguration());
            modelBuilder.Configurations.Add(new PaqueteConfiguration());
            modelBuilder.Configurations.Add(new PersonaConfiguration());
            modelBuilder.Configurations.Add(new ServicioHospedajeConfiguration());
            modelBuilder.Configurations.Add(new ServicioTuristicoConfiguration());
            modelBuilder.Configurations.Add(new TipoComprobanteConfiguration());
            modelBuilder.Configurations.Add(new TipoHospedajeConfiguration());
            modelBuilder.Configurations.Add(new TipoTransporteConfiguration());
            modelBuilder.Configurations.Add(new TransporteConfiguration());
            modelBuilder.Configurations.Add(new VentaPaqueteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}