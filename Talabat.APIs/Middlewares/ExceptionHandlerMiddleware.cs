
namespace Talabat.APIs.Middlewares
{
    public class ExceptionHandlerMiddleware(RequestDelegate next) 
    {
        private readonly RequestDelegate _next = next;

        public Task InvokeAsync(HttpContext context )
        {
            throw new NotImplementedException();
        }
    }
}
