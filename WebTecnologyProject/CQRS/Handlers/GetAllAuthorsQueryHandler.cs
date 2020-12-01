using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTechnologyProjectCore.Entities;
using WebTechnologyProjectCore.Interfaces;
using WebTecnologyProjectApi.CQRS.Queries;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository authorRepository;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await authorRepository.ListAllAsync();
        }
    }
}
