

using System.Collections.Concurrent;
using Talabat.Domain.Contracts.Presistence;

namespace Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        private readonly ConcurrentDictionary<string, object> _repository;

        public UnitOfWork(StoreDbContext dbContext)
        {
           _dbContext = dbContext;
            _repository = new();
        }

        public IGenericRepository<TEntity, TKey> GetRepositiry<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return (IGenericRepository<TEntity, TKey>)_repository.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_dbContext));
        }
        public Task<int> CompleteAsync()=>_dbContext.SaveChangesAsync();

        public ValueTask DisposeAsync()=>_dbContext.DisposeAsync();


    }
}
