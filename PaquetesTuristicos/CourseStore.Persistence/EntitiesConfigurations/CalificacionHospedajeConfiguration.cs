using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class CalificacionHospedajeConfiguration : EntityTypeConfiguration<CalificacionHospedaje>
    {
        public CalificacionHospedajeConfiguration()
        {
            //Table Configurations

            ToTable("CalificacionesHospedajes");

            // creacion primary key

            HasKey(a => a.CalificacionHospedajeId);
        }
    }
}
