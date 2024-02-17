namespace Saluteo.Repository
{
    using System;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : class
    {
        //Task<IQueryable<TEntity>> GetAllAsync();

        //Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        //Task<TEntity> GetByIdAsync(object id);

        //Task InsertAsync(TEntity entity);

        //Task UpdateAsync(TEntity entity);

        //Task DeleteAsync(object id);

        //Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        TEntity? GetById(object id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(object id);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        void LoadNavigationProperties(params Expression<Func<TEntity, object>>[] navigationProperties);
    }
}
