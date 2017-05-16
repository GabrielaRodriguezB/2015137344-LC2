using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class ComprobantePagoRepository : Repository<ComprobantePago>, IComprobantePagoRepository
    {
        private object _Context;

        public ComprobantePagoRepository(object context)
        {
            _Context = context;
        }
    }
}
