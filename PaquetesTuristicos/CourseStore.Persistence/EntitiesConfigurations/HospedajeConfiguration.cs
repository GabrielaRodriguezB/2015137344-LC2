using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class HospedajeConfiguration : EntityTypeConfiguration<Hospedaje>
    {
        public HospedajeConfiguration()
        {
            //Table Configurations

            ToTable("Hospedajes")

            // creacion primary key

            .HasKey(a => a.HospedajeId)
             .HasMany(c => c.Hospedaje)
                .WithMany(t => t.ServicioTuristico)
                .Map(m => m.ToTable("ServicioTuristicoHopedaje"));
        }
    }
}

        
            

           