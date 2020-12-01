using WebTechnologyProjectCore.Entities;
using Ardalis.Specification;

namespace WebTechnologyProjectCore.Specifications
{
    public class AllBooksIncludeAuthorsSpecification: Specification<Book>
    {
        public AllBooksIncludeAuthorsSpecification()
        {
            Query.Include(book => book.Author);
        }
    }
}
