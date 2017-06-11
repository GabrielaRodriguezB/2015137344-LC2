using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class ServicioTuristicoConfiguration : EntityTypeConfiguration<ServicioTuristico>
    {
        public ServicioTuristicoConfiguration()
        {
            //Table Configurations
            ToTable("ServiciosTuristicos");

            Property(c => c.PrecioServicioTuristico)
                .IsRequired();
        }
    }
}