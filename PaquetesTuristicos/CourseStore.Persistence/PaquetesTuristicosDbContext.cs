using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence
{
    class PaquetesTuristicosDbContext : DbContext
    {
        public DbSet<Alimentacion> Alimentacion { get; set; }
        public DbSet<CalificacionHospedaje> CalificacionHospedaje { get; set; }
        public DbSet<CategoriaHospedaje> CategoriaHospedaje { get; set; }
        public DbSet<CategoriaAlimentacion> CategoriaAlimentacion { get; set; }
        public DbSet<CategoriaTransporte> CategoriaTransporte { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ComprobantePago> ComprobantePago { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Hospedaje> Hospedaje { get; set; }
        public DbSet<MedioPago> MedioPago { get; set; }
        public DbSet<Paquete> Paquete { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<ServicioHospedaje> ServicioHospedaje { get; set; }
        public DbSet<ServicioTuristico> ServicioTuristico { get; set; }
        public DbSet<TipoComprobante> TipoComprobante { get; set; }
        public DbSet<TipoHospedaje> TipoHospedaje { get; set; }
        public DbSet<TipoTransporte> TipoTransporte { get; set; }
        public DbSet<Transporte> Transporte { get; set; }
        public DbSet<VentaPaquete> VentaPaquete { get; set; }
    }
}
