namespace Talabat.Application.Exceptions
{
    public class ValidationException:BadRequestException
    {
        public required IEnumerable<string> Errors { get; set; }
        public ValidationException(string message="Bad Request") : base(message)
        {
            
        }



    }
}
