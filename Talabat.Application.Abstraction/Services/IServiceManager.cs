using Talabat.Application.Abstraction.Services.Basket;
using Talabat.Application.Abstraction.Services.Products;

namespace Talabat.Application.Abstraction.Services
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; } 
        public IBasketService BasketService { get; } 
    }
}
 