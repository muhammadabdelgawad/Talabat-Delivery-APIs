namespace Talabat.Application.Abstraction.Models.Basket
{
    public record BasketDto
    {
        public required string Id { get; set; }
        public required IEnumerable<BasketItemDto> Items { get; set; } 
            = new List<BasketItemDto>();
    }
}
