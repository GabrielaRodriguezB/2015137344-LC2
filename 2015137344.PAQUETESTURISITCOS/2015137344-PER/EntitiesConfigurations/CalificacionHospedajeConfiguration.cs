using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class CalificacionHospedajeConfiguration : EntityTypeConfiguration<CalificacionHospedaje>
    {
        public CalificacionHospedajeConfiguration()
        {
            //Table Configurations
            ToTable("CalificacionesHospedaje");

            Property(c => c.Calificacion)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}