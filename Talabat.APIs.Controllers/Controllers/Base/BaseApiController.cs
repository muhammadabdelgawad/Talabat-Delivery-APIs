using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IServiceManager _servicesManager;
        public BaseApiController(IServiceManager servicesManager)
        {
            _servicesManager = servicesManager;
        }

        public BaseApiController()
        {
            
        }
    }
}
