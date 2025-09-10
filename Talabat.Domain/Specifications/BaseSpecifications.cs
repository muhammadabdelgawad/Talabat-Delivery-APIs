using System.Linq.Expressions;
using Talabat.Domain.Contracts;

namespace Talabat.Domain.Specifications
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
        public Expression<Func<TEntity, object>>? OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; } = null;

        public BaseSpecifications()
        {
            //Includes = new List<Expression<Func<TEntity, object>>>();
        }
        public BaseSpecifications(TKey id)
        {
            Criteria = E => E.Id.Equals(id);

        }
        #region Helper Methods

        private protected virtual void AddIncludes()
        {

        }

        private protected virtual void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
        {
            OrderBy = orderBy;
        }
        private protected virtual void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDesc)
        {
            OrderByDesc = orderByDesc;
        }
        private protected virtual void AddSorting(string sort)
        {

        }


        #endregion

    }
}
