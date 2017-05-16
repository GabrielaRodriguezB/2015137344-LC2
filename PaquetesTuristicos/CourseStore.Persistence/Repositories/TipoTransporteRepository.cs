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
    public class TipoTransporteRepository : Repository<TipoTransporte>, ITipoTransporteRepository

    {
        private object _Context;

        public TipoTransporteRepository(object context)
        {
            _Context = context;
        }

        public void Add(TipoTransporte entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TipoTransporte> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoTransporte> Find(Expression<Func<TipoTransporte, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TipoTransporte Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoTransporte> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TipoTransporte entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TipoTransporte> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoTransporte entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TipoTransporte> entities)
        {
            throw new NotImplementedException();
        }
    }
}
