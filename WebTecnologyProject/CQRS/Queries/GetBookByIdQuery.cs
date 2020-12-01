using WebTechnologyProjectCore.Entities;
using MediatR;

namespace WebTecnologyProjectApi.CQRS.Queries
{
    public class GetBookByIdQuery: IRequest<Book>
    {
        public GetBookByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
