﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class CategoriaTransporteRepository : Repository<CategoriaTransporte>, ICategoriaTransporteRepository
    {
        private object _Context;

        public CategoriaTransporteRepository(object context)
        {
            _Context = context;
        }
    }
}
