﻿using _2015137344_ENT.Entities;
using _2015137344_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _2015137344_PER.Repositories
{
    public class VentaPaqueteRepository : Repository<VentaPaquete>, IVentaPaqueteRepository
    {
        public VentaPaqueteRepository(DbContext context) : base(context)
        {
                
        }

        

    }
}