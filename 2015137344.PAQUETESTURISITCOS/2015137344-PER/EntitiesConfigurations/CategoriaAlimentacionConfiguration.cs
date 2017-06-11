using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class CategoriaAlimentacionConfiguration : EntityTypeConfiguration<CategoriaAlimentacion>
    {
        public CategoriaAlimentacionConfiguration()
        {
            //Table Configurations
            ToTable("CategoriasAlimentacion");

            Property(c => c.NomCategoriaAlimentacion)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}