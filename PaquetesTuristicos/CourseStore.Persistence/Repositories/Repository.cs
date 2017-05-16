using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PaquetesTuristicos.Entities.IRepositories;

namespace CourseStore.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        void IRepository<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Get(int? id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
