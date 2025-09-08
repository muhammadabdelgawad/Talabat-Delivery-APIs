using Talabat.Domain.Entities;
namespace Talabat.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications :BaseSpecifications<Product , int>
    {
        public ProductWithBrandAndCategorySpecifications()
            :base()
        {
            AddIncludes();
        }

       

        public ProductWithBrandAndCategorySpecifications(int id)
            :base(id)
        {
            AddIncludes();
        }
      
        private protected override void AddIncludes()
        {
            base.AddIncludes();
            Includes.Add(P => P.Brand!);
            Includes.Add(P => P.Category!);
        }
    }
}
