namespace Talabat.Application.Abstraction.Models.Basket
{
    public record BasketDto
    {
        public required int Id { get; set; }
        public required IEnumerable<BasketItemDto> Items { get; set; } 
            = new List<BasketItemDto>();
    }
}
