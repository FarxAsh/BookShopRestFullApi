using WebTechnologyProjectCore.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebTechnologyProjectCore.Interfaces
{
    public interface IBasketService
    {
        Task<BasketItem> AddBasketItemAsync(Book book);
        Task<BasketItem> RemoveBasketItemAsync(BasketItem basketItem);
        Task<IEnumerable<BasketItem>> GetAllBasketItemsAsync();
        Task RemoveAllBasketItemsAsync();

    }
}
