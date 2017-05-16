using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class CategoriaTransporteConfiguration : EntityTypeConfiguration<CategoriaTransporte>
    {
        public CategoriaTransporteConfiguration()
        {
            //Table Configurations

            ToTable("CategoriasTransportes");

            // creacion primary key

            HasKey(a => a.CategoriaTransporteId);
        }
    }
}