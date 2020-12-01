using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Entities;

namespace WebTechnologyProjectInfrastructure.Data
{
    public class AuthorRepository: EFRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ShopDbContext dbContext): base(dbContext) { }
    }
}
