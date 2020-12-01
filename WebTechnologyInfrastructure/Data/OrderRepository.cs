using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Entities;

namespace WebTechnologyProjectInfrastructure.Data
{
    public class OrderRepository: EFRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopDbContext context) : base(context) { }
    }
}
