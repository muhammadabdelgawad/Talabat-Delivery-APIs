namespace Talabat.Application.Exceptions
{
    public class NotFoundException :ApplicationException
    {
        public NotFoundException(string name , object key)
            : base($" The {name} With Id {key} was not found ")
        {
            
        }
    }
}
