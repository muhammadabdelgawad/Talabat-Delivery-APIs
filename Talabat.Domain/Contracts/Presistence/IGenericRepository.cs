namespace Talabat.Domain.Contracts.Presistence
{
    public interface IGenericRepository<TEntity,TKey> 
        where TEntity:BaseEntity<TKey> 
        where TKey: IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false);
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> spec);
        Task<TEntity> GetWithSpecAsync(ISpecifications<TEntity, TKey> spec);
        Task<TEntity?> GetAsync(int id);

        Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
