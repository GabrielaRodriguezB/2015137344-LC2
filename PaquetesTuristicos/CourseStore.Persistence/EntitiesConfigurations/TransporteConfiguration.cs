using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class TransporteConfiguration : EntityTypeConfiguration<Transporte>
    {
        public TransporteConfiguration()
        {
            //Table Configurations

            ToTable("Transportes")

            // creacion primary key

            .HasKey(a => a.TransporteId)
           
            .HasMany(c => c.Transporte)
                .WithMany(t => t.ServicioTuristico)
                .Map(m => m.ToTable("ServicioTuristicoTransporte"));
        }
    }
}

