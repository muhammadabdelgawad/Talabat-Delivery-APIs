using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Abstraction.Services.Basket;
using Talabat.Application.Abstraction.Services.Products;
using Talabat.Application.Services.Products;
using Talabat.Domain.Contracts.Presistence;
using Talabat.Infrastructure.Persistence.Repositories.Baskets;
namespace Talabat.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;
        private readonly IConfiguration _configuration;
        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper,
            IConfiguration configuration,Func<IBasketService> basketServiceFactory)
        {
            _configuration=configuration;
            _unitOfWork =unitOfWork;
            _mapper=mapper;
            _productService=new Lazy<IProductService>(()=>new ProductService(_unitOfWork,_mapper));
            _basketService = new Lazy<IBasketService>(basketServiceFactory);
        }
        public IProductService ProductService  =>_productService.Value;

        public IBasketService BasketService => _basketService.Value;
    }
}
 