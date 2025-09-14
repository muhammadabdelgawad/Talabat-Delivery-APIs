namespace Talabat.APIs.Controllers.Errors
{
    internal class ApiValidationErrorResponse(string? message = null) : ApiResponse(400,message)
    {
        public required IEnumerable<ValidationError> Errors { get; set; }
    }


    public class ValidationError 
    {
        public required string Field { get; set; }
        public required IEnumerable<string> Errors { get; set; }
    }





}
