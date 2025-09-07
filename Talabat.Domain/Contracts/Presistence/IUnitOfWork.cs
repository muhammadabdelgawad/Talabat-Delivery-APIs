using Talabat.Domain.Entities;

namespace Talabat.Domain.Contracts.Presistence
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity, TKey> GetRepositiry<TEntity, TKey>()
         where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>;

        Task<int> CompleteAsync();
    }
}
