﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class PaqueteRepository : Repository<Paquete>, IPaqueteRepository
    {
        private object _Context;

        public PaqueteRepository(object context)
        {
            _Context = context;
        }
    }
}