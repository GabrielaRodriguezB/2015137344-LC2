using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class TipoTransporteConfiguration : EntityTypeConfiguration<TipoTransporte>
    {
        public TipoTransporteConfiguration()
        {
            //Table Configurations

            ToTable("TiposTransportes");

            // creacion primary key

            HasKey(a => a.TipoTransporteId);
        }
    }
}
