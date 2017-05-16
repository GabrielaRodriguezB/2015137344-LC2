using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class AlimentacionConfiguration : EntityTypeConfiguration<Alimentacion>
        {
            public AlimentacionConfiguration()
            {
                //Table Configurations

                ToTable("Alimentaciones")

                // creacion primary key

                .HasKey(a => a.AlimentacionId)
                 .HasMany(c => c.Alimentacion)
                .WithMany(t => t.ServicioTuristico)
                .Map(m => m.ToTable("ServicioTuristicoAlimentacion"));
        }
        }
   }
