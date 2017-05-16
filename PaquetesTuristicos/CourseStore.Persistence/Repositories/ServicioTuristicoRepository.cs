using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class ServicioTuristicoRepository : Repository<ServicioHospedaje>, IServicioTuristicoRepository
    {
        private object _Context;

        public ServicioTuristicoRepository(object context)
        {
            _Context = context;
        }

        public void Add(ServicioTuristico entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ServicioTuristico> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicioTuristico> Find(Expression<Func<ServicioTuristico, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ServicioTuristico Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicioTuristico> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(ServicioTuristico entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ServicioTuristico> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ServicioTuristico entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<ServicioTuristico> entities)
        {
            throw new NotImplementedException();
        }
    }
}
