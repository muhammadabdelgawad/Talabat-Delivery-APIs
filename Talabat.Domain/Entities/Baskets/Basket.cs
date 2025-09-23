namespace Talabat.Domain.Entities.Basket
{
    public class Basket :BaseEntity<string>
    {
        public required IEnumerable<BasketItem> Items { get; set; }
    }
}
