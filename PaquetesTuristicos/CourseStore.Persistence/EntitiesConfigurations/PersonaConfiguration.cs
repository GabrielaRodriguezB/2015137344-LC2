using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class PersonaConfiguration : EntityTypeConfiguration<Persona>
    {
        public PersonaConfiguration()
        {
            //Table Configurations

            ToTable("Personas");

            // creacion primary key

            HasKey(a => a.PersonaId);
        }
    }
}
