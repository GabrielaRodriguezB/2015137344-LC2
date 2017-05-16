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
    public class CategoriaAlimentacionRepository : Repository<CategoriaAlimentacion>, ICategoriaAlimentacionRepository
    {
        private object _Context;

        public CategoriaAlimentacionRepository(object context)
        {
            _Context = context;
        }

        void IRepository<CategoriaAlimentacion>.Add(CategoriaAlimentacion entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<CategoriaAlimentacion>.AddRange(IEnumerable<CategoriaAlimentacion> entities)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CategoriaAlimentacion> IRepository<CategoriaAlimentacion>.Find(Expression<Func<CategoriaAlimentacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        CategoriaAlimentacion IRepository<CategoriaAlimentacion>.Get(int? id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CategoriaAlimentacion> IRepository<CategoriaAlimentacion>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<CategoriaAlimentacion>.Remove(CategoriaAlimentacion entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<CategoriaAlimentacion>.RemoveRange(IEnumerable<CategoriaAlimentacion> entities)
        {
            throw new NotImplementedException();
        }

        void IRepository<CategoriaAlimentacion>.Update(CategoriaAlimentacion entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<CategoriaAlimentacion>.UpdateRange(IEnumerable<CategoriaAlimentacion> entities)
        {
            throw new NotImplementedException();
        }
    }
}
