using Talabat.Application.Abstraction.Services.Products;

namespace Talabat.Application.Abstraction.Services
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; }
    }
}
 