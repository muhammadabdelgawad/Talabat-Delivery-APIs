using System.Linq.Expressions;
using Talabat.Domain.Contracts;

namespace Talabat.Domain.Specifications
{
    internal class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Predicate<TEntity>>? Criteria { get ; set ; }=null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = null;
        public BaseSpecifications()
        {
            Includes = new List<Expression<Func<TEntity, object>>>();
        }
        public BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);
            Includes = new List<Expression<Func<TEntity, object>>>();

        }
    }
}
