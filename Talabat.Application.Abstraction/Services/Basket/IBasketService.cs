using Talabat.Application.Abstraction.Models.Basket;

namespace Talabat.Application.Abstraction.Services.Basket
{
    public interface IBasketService
    {
        Task<BasketDto> GetCustomerBasket(string id);
        Task<BasketDto> UpdateCustomerBasket(BasketDto basket);
        Task DeleteCustomerBasketAsync(string id);

    }
}
