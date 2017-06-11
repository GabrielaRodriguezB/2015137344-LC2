using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class HospedajeConfiguration : EntityTypeConfiguration<Hospedaje>
    {
        public HospedajeConfiguration()
        {
            //Table Configurations
            ToTable("Hospedajes");

            Property(c => c.NomHospedaje)
                .IsRequired()
                .HasMaxLength(255);

            //Relations Configurations
            HasRequired(c => c.TipoHospedaje)
                .WithMany(c => c.Hospedajes);

            HasRequired(c => c.CalificacionHospedaje)
                .WithMany(c => c.Hospedajes);

            HasRequired(c => c.CategoriaHospedaje)
                .WithMany(c => c.Hospedajes);

            HasMany(c => c.ServiciosHospedaje)
                .WithMany(c => c.Hospedajes)
                .Map(m =>
                {
                    m.ToTable("DetalleHospedajeServiciosHospedaje");
                    m.MapLeftKey("ServicioTuristicoId");
                    m.MapRightKey("ServicioHospedajeId");
                });
        }
    }
}