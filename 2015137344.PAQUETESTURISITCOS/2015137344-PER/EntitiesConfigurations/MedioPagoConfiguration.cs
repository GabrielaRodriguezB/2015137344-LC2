using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class MedioPagoConfiguration : EntityTypeConfiguration<MedioPago>
    {
        public MedioPagoConfiguration()
        {
            //Table Configurations
            ToTable("MediosPago");

            Property(c => c.NomMedioPago)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}