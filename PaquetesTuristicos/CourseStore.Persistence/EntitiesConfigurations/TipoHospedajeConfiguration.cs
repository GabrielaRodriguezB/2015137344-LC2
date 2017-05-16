﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;

namespace CourseStore.Persistence.EntitiesConfigurations
{
    class TipoHospedajeConfiguration : EntityTypeConfiguration<TipoHospedaje>
    {
        public TipoHospedajeConfiguration()
        {
            //Table Configurations

            ToTable("TiposHospedajes");

            // creacion primary key

            HasKey(a => a.TipoHospedajeId);
        }
    }
}