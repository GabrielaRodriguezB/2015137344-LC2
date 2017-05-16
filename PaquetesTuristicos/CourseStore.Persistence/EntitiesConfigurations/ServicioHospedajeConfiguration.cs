using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class ServicioHospedajeConfiguration : EntityTypeConfiguration<ServicioHospedaje>
    {
        public ServicioHospedajeConfiguration()
        {
            //Table Configurations

            ToTable("ServiciosHospedajes");

            // creacion primary key

            HasKey(a => a.ServicioHospedajeId);
        }
    }
}
