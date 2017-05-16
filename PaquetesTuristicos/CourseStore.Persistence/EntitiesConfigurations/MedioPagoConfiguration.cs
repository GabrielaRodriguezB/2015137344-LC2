using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class MedioPagoConfiguration : EntityTypeConfiguration<MedioPago>
    {
        public MedioPagoConfiguration()
        {
            //Table Configurations

            ToTable("MediosPagos");

            // creacion primary key

            HasKey(a => a.MedioPagoId);
        }
    }
}