using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class ServicioTuristicoConfiguration : EntityTypeConfiguration<ServicioTuristico>
    {
        public ServicioTuristicoConfiguration()
            {
            //Table Configurations

            ToTable("ServiciosTuristicos")

            // creacion primary key

            .HasKey(a => a.ServicioTuristicoId)

            //Para que el Campo sea Requerido
            .Property(p => p.NombreServicio)
            .IsRequired()
            .HasMaxLength(255)

            //relación de mucho a muchos
            .HasMany(c => c.Hospedaje)
            .HasMany(c => c.Transporte)
            .HasMany(c => c.Alimentacion);


            
        }
    }
}
