using Talabat.Domain.Entities;
namespace Talabat.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndCategorySpecifications(string sort)
            : base()
        {
            AddIncludes();

            AddSorting(sort);

        }


        public ProductWithBrandAndCategorySpecifications(int id)
            : base(id)
        {
            AddIncludes();
        }
        #region Helper Methods

        private protected override void AddIncludes()
        {
            base.AddIncludes();
            Includes.Add(P => P.Brand!);
            Includes.Add(P => P.Category!);
        }

        private protected override void AddSorting(string sort)
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        } 
        #endregion
    }
}
