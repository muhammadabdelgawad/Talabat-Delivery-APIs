using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Base;
using Talabat.Application.Abstraction.DTOs.Products;
using Talabat.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Products
{
    public class ProductsController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts() 
        {
            var products = await serviceManager.ProductService.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id) 
        {
            var product = await serviceManager.ProductService.GetProductAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

    }
}
