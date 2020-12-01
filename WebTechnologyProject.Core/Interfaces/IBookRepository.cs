using WebTechnologyProjectCore.Entities;
using System.Threading.Tasks; 

namespace WebTechnologyProjectCore.Interfaces
{
    public interface IBookRepository: IAsyncRepository<Book>
    {
        Task<Book> GetByIdIncludeAuthorAsync(int id);
    }
}
