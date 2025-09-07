namespace Talabat.Domain.Entities
{
    public class ProductCategory:BaseAuditableEntity<int>
    {
        public required string Name { get; set; }

    }
    
}
