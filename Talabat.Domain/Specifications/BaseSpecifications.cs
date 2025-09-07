using System.Linq.Expressions;
using Talabat.Domain.Contracts;

namespace Talabat.Domain.Specifications
{
    internal class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get ; set ; }=null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
        public BaseSpecifications()
        {
            //Includes = new List<Expression<Func<TEntity, object>>>();
        }
        public BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);

        }
    }
}
