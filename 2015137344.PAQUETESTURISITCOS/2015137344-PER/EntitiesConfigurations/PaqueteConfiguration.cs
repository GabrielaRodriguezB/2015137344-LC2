using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class PaqueteConfiguration : EntityTypeConfiguration<Paquete>
    {
        public PaqueteConfiguration()
        {
            //Table Configurations
            ToTable("Paquetes");

            Property(c => c.NomPaquete)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.PrecioPaquete)
                .IsRequired();

            //Relations Configurations
            HasMany(c => c.ServiciosTuristicos)
                .WithMany(c => c.Paquetes)
                .Map(m =>
                {
                    m.ToTable("DetallePaqueteServiciosTuristicos");
                    m.MapLeftKey("PaqueteId");
                    m.MapRightKey("ServicioTuristicoId");
                });
        }
    }
}