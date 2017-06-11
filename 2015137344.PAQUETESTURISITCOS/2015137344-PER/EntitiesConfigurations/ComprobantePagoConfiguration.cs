using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class ComprobantePagoConfiguration : EntityTypeConfiguration<ComprobantePago>
    {
        public ComprobantePagoConfiguration()
        {
            //Table Configurations
            ToTable("ComprobantesPago");

            Property(c => c.NumComprobantePago)
                .IsRequired();

            //Relations Configurations
            HasRequired(c => c.TipoComprobante)
                .WithMany(c => c.ComprobantesPago);
        }
    }
}