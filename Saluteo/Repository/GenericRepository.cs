namespace Saluteo.Repository
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _dbContext;

        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            return Task.FromResult(query);
        }

        public async Task<TEntity?> GetByIdAsync(object id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task LoadNavigationPropertiesAsync(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }
            await query.LoadAsync();
        }
    }
}
