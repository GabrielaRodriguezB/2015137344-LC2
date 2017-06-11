using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class CategoriaTransporteConfiguration : EntityTypeConfiguration<CategoriaTransporte>
    {
        public CategoriaTransporteConfiguration()
        {
            //Table Configurations
            ToTable("CategoriasTransporte");

            Property(c => c.NomCategoriaTransporte)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}