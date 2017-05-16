using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class ComprobantePagoConfiguration : EntityTypeConfiguration<ComprobantePago>
    {
        public ComprobantePagoConfiguration()
        {
            //Table Configurations

            ToTable("ComprobantesPagos");

            // creacion primary key

            HasKey(a => a.ComprobantePagoId);
        }
    }
}