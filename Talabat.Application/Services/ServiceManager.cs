using AutoMapper;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Abstraction.Services.Products;
using Talabat.Application.Services.Products;
using Talabat.Domain.Contracts;
namespace Talabat.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Lazy<IProductService> _productService;
        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
            _productService=new Lazy<IProductService>(()=>new ProductService(_unitOfWork,_mapper));
        }
        public IProductService ProductService => =>_productService.Value;
    }
}
