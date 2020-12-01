using System.Collections.Generic;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Entities;
using WebTechnologyProjectCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebTechnologyProjectInfrastructure.Data
{
    public class BasketItemRepository: EFRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(ShopDbContext context): base(context) { }
        public async Task RemoveAllBasketItems(string basketGuid)
        {
            var basketItems = await dbContext.BasketItems.Where(bi => bi.basketGuid == basketGuid).ToListAsync();
            if (basketItems.Any())
            {
                dbContext.BasketItems.RemoveRange(basketItems);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
