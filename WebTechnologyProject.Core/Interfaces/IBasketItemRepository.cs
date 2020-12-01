using WebTechnologyProjectCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebTechnologyProjectCore.Interfaces
{
    public interface IBasketItemRepository: IAsyncRepository<BasketItem>
    {
        Task RemoveAllBasketItems(string basketGuid);
    }
}
