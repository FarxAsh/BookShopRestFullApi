using WebTechnologyProjectCore.Entities;
using Ardalis.Specification;
using WebTechnologyProjectCore.Enums;
namespace WebTechnologyProjectCore.Specifications
{
    public class FilteredBooksSpecification: Specification<Book>
    {
        public FilteredBooksSpecification(Genre? genre, string author)
        {
            Query.Where(book => (!genre.HasValue || book.Genre == genre) && 
                        (!string.IsNullOrEmpty(author) || book.Author.LastName == author));
        }
    }
}
