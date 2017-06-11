using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class AlimentacionConfiguration : EntityTypeConfiguration<Alimentacion>
    {
        public AlimentacionConfiguration()
        {
            //Table Configurations
            ToTable("Alimentaciones");

            Property(c => c.NomEstablecimiento)
                .IsRequired()
                .HasMaxLength(255);

            //Relations Configurations
            HasRequired(c => c.CategoriaAlimentacion)
                .WithMany(c => c.Alimentaciones);
        }
    }
}