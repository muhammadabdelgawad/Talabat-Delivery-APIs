using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Presistence;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.Infrastructure.Persistence.Repositories
{
    internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
      where TEntity : BaseEntity<TKey>
      where TKey : IEquatable<TKey>
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
        {
            if (typeof(TEntity) == typeof(Product))
                return withTracking ?(IEnumerable<TEntity>)await _dbContext.Set<Product>().Include(p => p.Brand).Include(p => p.Category).ToListAsync()
                                    :(IEnumerable<TEntity>)await _dbContext.Set<Product>().Include(p => p.Brand).Include(p => p.Category).AsNoTracking().ToListAsync();



            return withTracking ? await _dbContext.Set<TEntity>().ToListAsync()
                         : await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync(); 
        }

        public async Task<TEntity?> GetAsync(int id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task AddAsync(TEntity entity)  =>await _dbContext.Set<TEntity>().AddAsync(entity);
        public void Update(TEntity entity)=> _dbContext.Set<TEntity>().Update(entity);
        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

    }
}
