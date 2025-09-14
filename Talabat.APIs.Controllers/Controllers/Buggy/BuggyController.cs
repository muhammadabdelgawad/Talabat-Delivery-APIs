using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Talabat.APIs.Controllers.Base;
using Talabat.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Buggy
{
    public class BuggyController : BaseApiController
    {
        public BuggyController(IServiceManager servicesManager)
            : base(servicesManager)
        {


        }

        [HttpGet("not-found")]
        public IActionResult GetNotFoundRequest()
        {
            return NotFound();
        }


        [HttpGet("server-error")]
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();
        }

        [HttpGet("bad-request/{id}")]
        public IActionResult GetBadRequest()
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public IActionResult GetValidationErrorRequest(int id)
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorizedErrorRequest()
        {
            return Unauthorized();

        }
       
        [HttpGet("forbidden")]
        public IActionResult GetForbiddenErrorRequest()
        {
            return Forbid();

        }



    }
}