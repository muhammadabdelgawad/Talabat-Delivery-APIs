using Talabat.Domain.Entities;
namespace Talabat.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product, int>
    {


        public ProductWithBrandAndCategorySpecifications(string? sort, int? brandId, int? categoryId
            , int pageIndex, int pageSize, string? search)
            : base(p =>
                   (string.IsNullOrEmpty(search) || p.NormalizedName.Contains(search))
                   &&
                  (!brandId.HasValue || p.BrandId == brandId.Value)
                   &&
                   (!categoryId.HasValue || p.CategoryId == categoryId.Value)
                  )
        {
            AddIncludes();

            AddSorting(sort);

            AddPagination(pageSize * (pageIndex - 1), pageSize);

        }


        public ProductWithBrandAndCategorySpecifications(int id)
            : base(id)
        {
            AddIncludes();
        }

        public ProductWithBrandAndCategorySpecifications(int? brandId, int? categoryId, string? search)
            : base(p =>
                   (string.IsNullOrEmpty(search) || p.NormalizedName.Contains(search))
                   &&
                   (!brandId.HasValue || p.BrandId == brandId.Value)
                   &&
                   (!categoryId.HasValue || p.CategoryId == categoryId.Value)
                  )
        {

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
