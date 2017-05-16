using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class VentaPaqueteConfiguration : EntityTypeConfiguration<VentaPaquete>
    {
        public VentaPaqueteConfiguration()
        {
            //Table Configurations

            ToTable("VentasPaquetes");

            // creacion primary key

            HasKey(a => a.VentaPaqueteId);
        }
    }
}
