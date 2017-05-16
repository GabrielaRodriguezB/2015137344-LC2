using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class CategoriaHospedajeConfiguration : EntityTypeConfiguration<CategoriaHospedaje>
    {
        public CategoriaHospedajeConfiguration()
        {
            //Table Configurations

            ToTable("CategoriasHospedajes");

            // creacion primary key

            HasKey(a => a.CategoriaHospedajeId);
        }
    }
}
