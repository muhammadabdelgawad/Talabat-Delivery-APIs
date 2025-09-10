using AutoMapper;
using Talabat.Application.Abstraction.DTOs.Products;
using Talabat.Application.Abstraction.Models.Products;
using Talabat.Application.Abstraction.Services.Products;
using Talabat.Domain.Contracts.Presistence;
using Talabat.Domain.Entities;
using Talabat.Domain.Specifications.Products;

namespace Talabat.Application.Services.Products
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync(string sort)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(sort);

            var products = await unitOfWork.GetRepositiry<Product, int>().GetAllWithSpecAsync(specs);
            var productToReturn = mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            return productToReturn;
        }
        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);

            var Product = await unitOfWork.GetRepositiry<Product, int>().GetWithSpecAsync(spec);

            var productToReturn = mapper.Map<ProductToReturnDto>(Product);
            return productToReturn;
        }

        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {

            var brands = await unitOfWork.GetRepositiry<ProductBrand, int>().GetAllAsync();
            var brandToReturn = mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandToReturn;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await unitOfWork.GetRepositiry<ProductCategory, int>().GetAllAsync();
            var categoryToReturn = mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoryToReturn;
        }


    }
}
