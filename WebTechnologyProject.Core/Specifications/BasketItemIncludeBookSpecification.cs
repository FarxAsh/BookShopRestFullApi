using WebTechnologyProjectCore.Entities;
using Ardalis.Specification;

namespace WebTechnologyProjectCore.Specifications
{
    public class BasketItemIncludeBookSpecification: Specification<BasketItem>
    {
        public BasketItemIncludeBookSpecification(string basketGuid)
        {
            Query.Where(bi => bi.basketGuid == basketGuid).Include(bi => bi.Book);
        }
    }
}
