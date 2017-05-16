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
    public class AlimentacionRepository : Repository<Alimemtacion>, IAlimentacionRepository
    {
        private PaquetesTuristicosDbContext _Context;
        private object _Context1;

        public AlimentacionRepository(PaquetesTuristicosDbContext context)
        {
            _Context = context;
        }

        public AlimentacionRepository(object context1)
        {
            _Context1 = context1;
        }

        public void Add(Alimentacion entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Alimentacion> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alimentacion> Find(Expression<Func<Alimentacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Alimentacion Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alimentacion> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Alimentacion entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Alimentacion> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Alimentacion entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Alimentacion> entities)
        {
            throw new NotImplementedException();
        }
    }
}
