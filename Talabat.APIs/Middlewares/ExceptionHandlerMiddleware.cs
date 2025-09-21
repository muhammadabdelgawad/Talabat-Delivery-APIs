
using System.Net;
using Talabat.APIs.Controllers.Errors;

namespace Talabat.APIs.Middlewares
{
    public class ExceptionHandlerMiddleware 
    {
        private readonly RequestDelegate _next ;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next , ILogger<ExceptionHandlerMiddleware> logger ,
            IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
            
        }
        public async Task InvokeAsync(HttpContext context )
        {
            try
            {
                await _next(context);
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
                
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var  response = _environment.IsDevelopment() 
                    ? new APiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace!.ToString()) 
                    : new APiExceptionResponse((int)HttpStatusCode.InternalServerError,ex.Message);

                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
