using _2015137344_ENT.Entities;
using _2015137344_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _2015137344_PER.Repositories
{
    public class CategoriaTransporteRepository : Repository<CategoriaTransporte>, ICategoriaTransporteRepository
    {
        public CategoriaTransporteRepository(DbContext context) : base(context)
        {

        }
    }
}