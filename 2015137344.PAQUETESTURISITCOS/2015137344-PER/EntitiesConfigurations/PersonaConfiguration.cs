using _2015137344_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.EntitiesConfigurations
{
    public class PersonaConfiguration : EntityTypeConfiguration<Persona>
    {
        public PersonaConfiguration()
        {
            //Table Configurations
            ToTable("Personas");

            Property(c => c.DocIdPersona)
                .IsRequired();

            Property(c => c.NomPersona)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.ApePatPersona)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.ApeMatPersona)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}