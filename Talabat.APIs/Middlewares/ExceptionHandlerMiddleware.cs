
using System.Net;
using System.Reflection.Metadata.Ecma335;
using Talabat.APIs.Controllers.Errors;
using Talabat.Application.Exceptions;

namespace Talabat.APIs.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger,
            IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;

        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    _logger.LogError(ex, ex.Message, ex.StackTrace!, ex.ToString());
                }
                else
                {

                }

                await HandleExceptions(httpContext, ex);
            }
        }

        private async Task HandleExceptions(HttpContext context, Exception ex)
        {
            ApiResponse response;
            switch (ex)
            {
                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response = new ApiResponse((int)HttpStatusCode.NotFound);
                    break;
                case ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new ApiValidationErrorResponse( ex.Message) { Errors = (IEnumerable<ValidationError>)validationException.Errors };
                    break;
                case BadRequestException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new ApiResponse((int)HttpStatusCode.BadRequest);
                    break;
                case UnAuthorizedException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response = new ApiResponse((int)HttpStatusCode.Unauthorized);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = _environment.IsDevelopment()
                       ? new APiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace!.ToString())
                       : new APiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message);
                    break;
            }
            context.Response.ContentType = "application/json";



            await context.Response.WriteAsync(response.ToString());
        }
    }
}
