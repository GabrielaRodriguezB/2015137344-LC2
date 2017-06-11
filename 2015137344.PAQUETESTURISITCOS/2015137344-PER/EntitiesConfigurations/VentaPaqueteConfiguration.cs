using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class VentaPaqueteConfiguration : EntityTypeConfiguration<VentaPaquete>
    {
        public VentaPaqueteConfiguration()
        {
            //Table Configurations
            ToTable("VentasPaquetes");

            Property(c => c.MontoAPagar)
                .IsRequired();

            //Relations Configurations
            HasRequired(c => c.Cliente)
                .WithMany(c => c.VentasPaquetes);

            HasRequired(c => c.Empleado)
                .WithMany(c => c.VentasPaquetes);

            HasRequired(c => c.ComprobantePago)
                .WithRequiredPrincipal(c => c.VentaPaquete);

            HasRequired(c => c.MedioPago)
                .WithMany(c => c.VentasPaquetes);

            HasMany(c => c.Paquetes)
                .WithMany(c => c.VentasPaquetes)
                .Map(m =>
                {
                    m.ToTable("DetalleVentaPaquetes");
                    m.MapLeftKey("VentaPaqueteId");
                    m.MapRightKey("PaqueteId");
                });
        }
    }
}