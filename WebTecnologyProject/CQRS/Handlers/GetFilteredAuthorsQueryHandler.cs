using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebTechnologyProjectCore.Entities;
using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Enums;
using WebTechnologyProjectCore.Specifications;
using WebTecnologyProjectApi.CQRS.Queries;
using System.Threading;

namespace WebTecnologyProjectApi.CQRS.Handlers
{
    public class GetFilteredAuthorsQueryHandler: IRequestHandler<GetFilteredAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository authorRepository;

        public GetFilteredAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> Handle(GetFilteredAuthorsQuery request, CancellationToken cancellationToken)
        {
            var specification = new FilteredAuthorsSpecification(request.Genre);
            return await authorRepository.ListAsync(specification);
        }
    }
}
