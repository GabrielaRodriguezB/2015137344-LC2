using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class CalificacionHospedajeRepository : Repository<CalificacionHospedaje>, ICalificacionHospedajeRepository
    {
        private object _Context;

        public CalificacionHospedajeRepository(object context)
        {
            _Context = context;
        }
    }
}
