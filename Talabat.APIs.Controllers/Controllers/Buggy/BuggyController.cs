using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Talabat.APIs.Controllers.Base;
using Talabat.APIs.Controllers.Errors;
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
            return NotFound(new ApiResponse(404));
        }


        [HttpGet("server-error")]
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();
        }

        [HttpGet("bad-request")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("bad-request/{id}")]
        public IActionResult GetValidationErrorRequest(int id)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(p => p.Value.Errors.Count > 0)
                    .Select(p => new ValidationError()
                    {
                        Field = p.Key,
                        Errors = p.Value.Errors.Select(e => e.ErrorMessage)
                    });
                return BadRequest(new ApiValidationErrorResponse() { Errors = errors });
            }
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