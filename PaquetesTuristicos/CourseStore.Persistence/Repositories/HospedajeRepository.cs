using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class HospedajeRepository : Repository<Hospedaje>, IHospedajeRepository
    {
        private object _Context;

        public HospedajeRepository(object context)
        {
            _Context = context;
        }
    }
}
