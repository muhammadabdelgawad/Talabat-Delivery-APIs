using System.Text.Json;

namespace Talabat.APIs.Controllers.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiResponse(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = message?? GetDefualtMessageForStatusCode(statusCode) ;
        } 

        private string? GetDefualtMessageForStatusCode(int statusCode)
        {
           return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                403 => "Forbidden, you are",
                404 => "Resource found, it was not",
                500 => "Server Error",
                _ => null
            };
        }


        public override string ToString()
        {
            var serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this,serializerOptions);
        }
    }
}
