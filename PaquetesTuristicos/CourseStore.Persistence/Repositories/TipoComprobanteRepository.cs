using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    class TipoComprobanteRepository : Repository<TipoComprobante>, ITipoComprobanteRepository
    {
        private object _Context;

        public TipoComprobanteRepository(object context)
        {
            _Context = context;
        }
    }
}
