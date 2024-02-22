namespace Saluteo.Repository
{
    using System;
    using System.Linq.Expressions;

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //Task<IQueryable<TEntity>> GetAllAsync();

        //Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        //Task<TEntity> GetByIdAsync(object id);

        //Task InsertAsync(TEntity entity);

        //Task UpdateAsync(TEntity entity);

        //Task DeleteAsync(object id);

        //Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IQueryable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(object id);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(object id);

        Task LoadNavigationPropertiesAsync(params Expression<Func<TEntity, object>>[] navigationProperties);
    }
}
