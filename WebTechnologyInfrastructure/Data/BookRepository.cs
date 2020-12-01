using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Entities;
using System.Threading.Tasks;

namespace WebTechnologyProjectInfrastructure.Data
{
    public class BookRepository: EFRepository<Book>, IBookRepository
    {
        public BookRepository(ShopDbContext dbContext) : base(dbContext) { }

        public async Task<Book> GetByIdIncludeAuthorAsync(int id)
        {
            return await dbContext.Books.FindAsync(id);
        }
    }
}
