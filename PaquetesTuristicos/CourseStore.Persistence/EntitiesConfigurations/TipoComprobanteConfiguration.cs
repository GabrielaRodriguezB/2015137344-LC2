using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class TipoComprobanteConfiguration : EntityTypeConfiguration<TipoComprobante>
    {
        public TipoComprobanteConfiguration()
        {
            //Table Configurations

            ToTable("TiposComprobantes");

            // creacion primary key

            HasKey(a => a.TipoComprobanteId);
        }
    }
}
    