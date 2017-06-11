using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class TransporteConfiguration : EntityTypeConfiguration<Transporte>
    {
        public TransporteConfiguration()
        {
            //Table Configurations
            ToTable("Transportes");

            Property(c => c.NomEmpresaTransporte)
                .IsRequired()
                .HasMaxLength(255);

            //Relations Configurations
            HasRequired(c => c.TipoTransporte)
                .WithMany(c => c.Transportes);

            HasRequired(c => c.CategoriaTransporte)
                .WithMany(c => c.Transportes);
        }
    }
}