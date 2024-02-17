namespace Saluteo.Repository
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class RepositoryContext<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _dbContext;

        public RepositoryContext(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            var x = _dbContext.Set<TEntity>();
            return x;
        }

        public TEntity? GetById(object id)
        {
            var x = _dbContext.Set<TEntity>().Find(id);
            return x;
        }

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void LoadNavigationProperties(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            query.Load();
        }
    }
}
