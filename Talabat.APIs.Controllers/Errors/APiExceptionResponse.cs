using System.Text.Json;

namespace Talabat.APIs.Controllers.Errors
{
    public class APiExceptionResponse:ApiResponse
    {
        public string? Details { get; set; }

        public APiExceptionResponse(int statusCode , string? message=null , string? details=null)
            : base(statusCode, message)
        {
            Details = details;
        }
        public override string ToString()
        {
            var serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, serializerOptions);
        }
    }
}
