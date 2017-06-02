using InmuebleVenta.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace InmuebleVenta.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext _Context;

        public Repository(DbContext context)
        {
            _Context = context;
        }

        public void Delete(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity Get(int? id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }
        public void Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
        }

        /*
        void IRepository<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
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
        */
    }
}
