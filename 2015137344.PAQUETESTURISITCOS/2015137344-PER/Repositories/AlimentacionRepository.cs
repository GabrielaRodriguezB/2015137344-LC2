using _2015137344_ENT.Entities;
using _2015137344_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015137344_PER.Repositories
{
    public class AlimentacionRepository : Repository<Alimentacion>, IAlimentacionRepository
    {
        public AlimentacionRepository(PaquetesTuristicosDbContext context) : base(context)
        {

        }
    }
}