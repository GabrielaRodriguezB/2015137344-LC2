using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class PaqueteConfiguration : EntityTypeConfiguration<Paquete>
    {
        public PaqueteConfiguration()
        {
            //Table Configurations

            ToTable("Paquetes");

            // creacion primary key

            HasKey(a => a.PaqueteId);
        }
    }
}