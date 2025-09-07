using System.Linq.Expressions;

namespace Talabat.Domain.Contracts
{
    public interface ISpecifications <TEntity ,TKey>
        where TEntity: BaseEntity<TKey>
        where TKey: IEquatable<TKey>
    {
        public Expression<Predicate<TEntity>> Criteria { get; set; }
    }
}
 