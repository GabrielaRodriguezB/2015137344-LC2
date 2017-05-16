﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class MedioPagoRepository : Repository<MedioPago>, IMedioPagoRepository
    {
        private object _Context;

        public MedioPagoRepository(object context)
        {
            _Context = context;
        }
    }
}
